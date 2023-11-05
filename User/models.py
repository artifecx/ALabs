from django.contrib.auth.models import AbstractBaseUser, BaseUserManager, PermissionsMixin
from django.db import models


# Create your models here.
class CustomUserManager(BaseUserManager):
    def create_user(self, username, email, password, **extra_fields):
        if not username:
            raise ValueError('The Username field must be set')
        if not email:
            raise ValueError('The Email field must be set')
        email = self.normalize_email(email)
        user = self.model(username=username, email=email, **extra_fields)
        user.set_password(password)
        user.save(using=self._db)
        return user

    def create_superuser(self, username, email, password, **extra_fields):
        extra_fields.setdefault('is_staff', True)
        extra_fields.setdefault('is_superuser', True)
        return self.create_user(username, email, password, **extra_fields)


class CustomUser(AbstractBaseUser, PermissionsMixin):
    username = models.CharField(max_length=30, unique=True)
    email = models.EmailField(unique=True)
    first_name = models.CharField(max_length=30)
    last_name = models.CharField(max_length=30)
    profile_picture = models.ImageField(
        upload_to='profile_pictures/',
        null=True,
        blank=True
    )
    is_active = models.BooleanField(default=True)
    is_staff = models.BooleanField(default=False)
    date_joined = models.DateTimeField(auto_now_add=True)

    objects = CustomUserManager()

    USERNAME_FIELD = 'username'
    REQUIRED_FIELDS = ['email', 'first_name', 'last_name']

    def __str__(self):
        return self.username


class UserProfile(models.Model):
    user = models.OneToOneField(CustomUser, on_delete=models.CASCADE)
    points = models.PositiveIntegerField(default=0)


class UserRanking(models.Model):
    user = models.ForeignKey(CustomUser, on_delete=models.CASCADE)
    category = models.CharField(max_length=100)  # e.g., "NFA" "DFA" "RegEx"
    ranking_value = models.PositiveIntegerField()

    class Meta:
        unique_together = ('user', 'category')