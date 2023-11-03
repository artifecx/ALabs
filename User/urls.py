from django.urls import path

from User import views
from User.views import CustomLoginView

urlpatterns = [
    path('register/', views.register, name='register'),
    path('login/', CustomLoginView.as_view(), name='login'),
    path('logout/', views.user_logout, name='logout'),
]