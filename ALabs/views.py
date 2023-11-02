from django.shortcuts import render, redirect
from django.contrib.auth.decorators import login_required


# Create your views here.
@login_required
def dashboard(request):
    user = request.user
    return render(request, 'dashboard.html', {'user': user})


@login_required
def home(request):
    # auto redirect to dashboard when logged in
    return redirect('dashboard')