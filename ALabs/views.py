from django.shortcuts import render


# TODO: remove later
def index(request):
    return render(request, 'index.html')