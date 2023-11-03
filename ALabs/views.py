from django.shortcuts import render, redirect
from django.contrib.auth.decorators import login_required
from User.forms import UserProfileForm


# Create your views here.
@login_required
def dashboard(request):
    user = request.user

    if request.method == 'POST':
        form = UserProfileForm(request.POST, request.FILES, instance=user)
        if form.is_valid():
            form.save()
    form = UserProfileForm(instance=user)

    return render(request, 'dashboard.html', {'user': user, 'form': form})


@login_required
def home(request):
    # auto redirect to dashboard when logged in
    return redirect('dashboard')