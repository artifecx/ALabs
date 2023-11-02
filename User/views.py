from django.shortcuts import render, redirect
from django.core.mail import send_mail
from django.urls import reverse_lazy
from django.contrib.auth import login, logout
from django.contrib.auth.views import LoginView
from django.contrib.auth.decorators import login_required

from ALabs import settings
from .forms import UserRegistrationForm, UserLoginForm


# Create your views here.
def register(request):
    if request.method == 'POST':
        form = UserRegistrationForm(request.POST)
        if form.is_valid():
            user = form.save(commit=False)
            user.set_password(form.cleaned_data['password'])
            user.save()

            # Send a confirmation email
            subject = 'Registration Confirmation'
            message = 'Test email'
            from_email = 'a.labsinnovations@gmail.com'
            recipient_list = [user.email]
            send_mail(subject, message, from_email, recipient_list, fail_silently=False)

            return redirect('login')
    else:
        form = UserRegistrationForm()

    return render(request, 'register.html', {'form': form})


class CustomLoginView(LoginView):
    authentication_form = UserLoginForm
    template_name = 'login.html'

    def form_valid(self, form):
        remember_me = self.request.POST.get('remember_me')
        if remember_me:
            self.request.session.set_expiry(settings.REMEMBER_ME_SESSION_DURATION)
        else:
            self.request.session.set_expiry(0)  # Use the value from SESSION_COOKIE_AGE
        login(self.request, form.get_user())
        self.request.session['username'] = form.cleaned_data.get('username')
        return super().form_valid(form)

    def get_success_url(self):
        return reverse_lazy('dashboard')


def user_logout(request):
    logout(request)
    return redirect('login')