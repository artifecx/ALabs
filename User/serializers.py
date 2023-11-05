from rest_framework import serializers
from rest_framework.exceptions import ValidationError
from django.contrib.auth.password_validation import validate_password
from .models import CustomUser


class UserProfileSerializer(serializers.ModelSerializer):
    class Meta:
        model = CustomUser
        fields = ['username', 'profile_picture']


class UserRegistrationSerializer(serializers.ModelSerializer):
    password = serializers.CharField(write_only=True, style={'input_type': 'password'})
    password_confirm = serializers.CharField(write_only=True, label="Confirm Password", style={'input_type': 'password'})

    class Meta:
        model = CustomUser
        fields = ['username', 'email', 'password', 'password_confirm', 'first_name', 'last_name']

    def validate(self, data):
        password = data.get('password')
        password_confirm = data.get('password_confirm')

        if password and password_confirm and password != password_confirm:
            raise ValidationError("Passwords do not match")

        return data

    def validate_password(self, value):
        try:
            validate_password(value, self.instance)
        except ValidationError as e:
            raise serializers.ValidationError(str(e))
        return value

    def validate_email(self, value):
        if CustomUser.objects.filter(email=value).exists():
            raise serializers.ValidationError("This email already exists.")
        return value