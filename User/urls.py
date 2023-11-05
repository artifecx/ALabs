from django.urls import path

from .api import *

urlpatterns = [
    path('register/', user_registration_view, name='user-registration'),
    path('login/', custom_login_view, name='login'),
    path('', home, name='home'),
    path('dashboard/', dashboard, name='dashboard'),
    path('logout/', logout_view, name='logout'),
]