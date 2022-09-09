from flask import Flask, request
from flask_restful import Resource, Api, reqparse
from flask_jwt import JWT, jwt_required
#from flask_jwt_extended import JWTManager

from security import authenticate, identity

app = Flask(__name__)
#app.secret_key = 'jose'
api = Api(app) # instantiating the api

#jwt = JWT(app, authenticate, identity)
#jwt = JWTManager(app) # /auth endpoint

items = []

class Item(Resource): # defining the resource
    parser = reqparse.RequestParser()  # used to parse the request
    parser.add_argument('price',  # add arguments to ensure it is included in the json
                        type=float,
                        required=True,
                        help="This field cannot be left blank"
                        )
    #@jwt_required()
    def get(self, name): # defining the available methods (CRUD)
        item = next(filter(lambda x: x['name'] == name, items), None) # iterates through items, if not found, return None
        return {'item': item}, 200 if item else 404 # returns item, 200 or 404 if item is None

    def post(self, name):
        if next(filter(lambda x: x['name'] == name, items), None): # if the item exists, return error message
            return {"message": f"An item with name '{name}' already exists."}, 400
        requestData = Item.parser.parse_args()
        item = {'name': name, 'price': requestData['price']}
        items.append(item)
        return item, 201

    def delete(self, name):
        global items
        items = list(filter(lambda x: x['name'] != name, items))
        return {'message': 'Item deleted'}

    def put(self, name):
        requestData = Item.parser.parse_args()
        item = next(filter(lambda x: x['name'] == name, items), None)
        if item is None:
            item = {'name': name, 'price': requestData['price']}
            items.append(item)
        else:
            item.update(requestData)
        return item

class ItemList(Resource):
    def get(self):
        return {'items': items}


api.add_resource(Item, '/item/<string:name>') # make the resource accessible by the api, and add the endpoint
api.add_resource(ItemList, '/items')

app.run(port=5000, debug=True)