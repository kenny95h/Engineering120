from hmac import compare_digest
from user import User

def authenticate(username, password):
    user = User.find_by_username(username) # runs database query to find result in database
    if user and compare_digest(user.password, password):
        return user

def identity(payload):
    user_id = payload['identity']
    return User.find_by_id(user_id)