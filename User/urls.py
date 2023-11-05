from django.urls import path

from .api import logout_view, dashboard, home, user_registration_view, custom_login_view

urlpatterns = [
    path('register/', user_registration_view, name='user-registration'),
    path('login/', custom_login_view, name='login'),
    path('', home, name='home'),
    path('dashboard/', dashboard, name='dashboard'),
    path('logout/', logout_view, name='logout'),
]