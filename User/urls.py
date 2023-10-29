from django.urls import path
from .views import CustomLoginView
from . import views

urlpatterns = [
    # Other URL patterns
    path('register/', views.register, name='register'),
    path('login/', CustomLoginView.as_view(), name='login'),
]