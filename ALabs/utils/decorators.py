from django.shortcuts import redirect


# this thing is the only one that works with classes smh
def redirect_if_logged_in_class(view_class):
    def _wrapped_view(request, *args, **kwargs):
        if request.user.is_authenticated:
            return redirect('dashboard')
        return view_class(request, *args, **kwargs)

    return _wrapped_view