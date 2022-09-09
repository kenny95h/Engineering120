import hmac

from flask_jwt_extended import create_access_token
from flask_restful import Resource, reqparse


class User:
    def __init__(self, _id, username, password):
        self.id = _id
        self.username = username
        self.password = password

class UserLogin(Resource):
    parser = reqparse.RequestParser()
    parser.add_argument('username',
                        type=str,
                        required=True,
                        help="This field cannot be blank."
                        )
    parser.add_argument('password',
                        type=str,
                        required=True,
                        help="This field cannot be blank."
                        )
    @classmethod
    def post(cls):
        pass
        # get data from parser
        data = cls.parser.parse_args()
        # find user in database
        #user = UserModel.find_by_username(data['username'])
        # check password
        #if user and hmac.compare_digest(user.password, data['password']):
        #    access_token = create_access_token(identity=user.id, fresh=True)
        # create access token
        # create refresh toke
