import hmac
from user import User

users = [
    User(1, 'bob', 'asdf')
]

username_mapping = { u.username: u for u in users } # assigns username as key to user value

userid_mapping = { u.id: u for u in users }

def authenticate(username, password):
    user = username_mapping.get(username, None) # a method for returning value in dictionary, allows us to set default if not there
    if user and hmac.compare_digest(user.password, password): # hmac is a safe way of comparing different char encodings
        return user

def identity(payload):
    user_id = payload['identity']
    return userid_mapping.get(user_id, None)