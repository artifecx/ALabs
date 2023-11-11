from rest_framework.decorators import api_view, permission_classes
from rest_framework.response import Response
from rest_framework import status
from rest_framework.permissions import IsAuthenticated
from django.contrib.auth.decorators import login_required
from django.contrib.auth.forms import AuthenticationForm
from django.shortcuts import redirect
from django.contrib.auth import logout, login
from django.core.mail import send_mail

from .serializers import *
from ALabs import settings


@api_view(['GET', 'POST'])
@login_required
def dashboard(request):
    user = request.user

    if request.method == 'POST':
        serializer = UserProfileSerializer(user, data=request.data)
        if serializer.is_valid():
            serializer.save()
            return Response(serializer.data, status=status.HTTP_200_OK)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)

    serializer = UserProfileSerializer(user)
    return Response(serializer.data, status=status.HTTP_200_OK)


@api_view(['GET'])
@login_required
def home(request):
    # Redirect to the dashboard
    return redirect('dashboard')


@api_view(['POST', 'GET'])
@permission_classes([IsAuthenticated])
def logout_view(request):
    logout(request)
    return Response({'message': 'Successfully logged out.'}, status=status.HTTP_200_OK)


@api_view(['POST', 'GET'])
def user_registration_view(request):
    if request.user.is_authenticated:
        # TODO: add javascript to redirect user to dashboard client-side after a few seconds
        return Response({'detail': 'User is already authenticated. Redirecting to the dashboard...', 'redirect': '/dashboard'}, status=status.HTTP_400_BAD_REQUEST)

    if request.method == 'POST':
        serializer = UserRegistrationSerializer(data=request.data)

        if serializer.is_valid():
            user = serializer.save()

            # Send a confirmation email
            subject = 'Registration Confirmation'
            message = 'Test email'
            from_email = 'a.labsinnovations@gmail.com'
            recipient_list = [user.email]
            send_mail(subject, message, from_email, recipient_list, fail_silently=False)

            return Response({'detail': 'Registration successful. Please check your email.'}, status=status.HTTP_201_CREATED)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)

    return Response({'detail': 'Registration form'}, status=status.HTTP_200_OK)


@api_view(['POST', 'GET'])
def custom_login_view(request):
    if request.user.is_authenticated:
        # TODO: add javascript to redirect user to dashboard client-side after a few seconds
        return Response({'detail': 'User is already authenticated. Redirecting to the dashboard...', 'redirect': '/dashboard'}, status=status.HTTP_400_BAD_REQUEST)

    if request.method == 'POST':
        authentication_form = AuthenticationForm(data=request.data)
        if authentication_form.is_valid():
            user = authentication_form.get_user()
            login(request, user)
            username = user.username

            remember_me = request.data.get('remember_me')
            if remember_me:
                request.session.set_expiry(settings.REMEMBER_ME_SESSION_DURATION)
            else:
                request.session.set_expiry(0)  # Use the value from SESSION_COOKIE_AGE

            return Response({'username': username, 'detail': 'Login successful'}, status=status.HTTP_200_OK)

        return Response(authentication_form.errors, status=status.HTTP_400_BAD_REQUEST)

    return Response({'detail': 'Login form'}, status=status.HTTP_200_OK)