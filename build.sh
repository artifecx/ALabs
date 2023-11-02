# exit on error
set -o errexit

pip install -r requirements.txt

py manage.py collectstatic --no-input