from flask_restful import Resource, reqparse
from flask_jwt_extended import jwt_required, get_jwt, get_jwt_identity
from models.item import ItemModel

class Item(Resource):
    parser = reqparse.RequestParser()
    parser.add_argument('price',
        type=float,
        required=True,
        help="This field cannot be left blank!"
    )
    parser.add_argument('store_id',
                        type=int,
                        required=True,
                        help="Every item needs a store id"
                        )

    @jwt_required()
    def get(self, name):
        item = ItemModel.find_by_name(name)
        if item:
            return item.json()
        return {'message': 'Item not found'}, 404

    @jwt_required(fresh=True)
    def post(self, name):
        if ItemModel.find_by_name(name):
            return {'message': "An item with name '{}' already exists.".format(name)}, 400

        data = Item.parser.parse_args()

        item = ItemModel(name, data['price'], data['store_id'])

        try: # try to insert the item in to database
            item.save_to_db()
        except: # if this fails (connection error, etc.) then error message is returned
            return {"message": "An error occurred inserting the item"}, 500 # return internal server error

        return item.json(), 201

    @jwt_required()
    def delete(self, name):
        claims = get_jwt()
        if not claims['is_admin']:
            return {'message': 'Admin privilege required'}

        item = ItemModel.find_by_name(name)
        if item:
            item.delete_from_db()
        return {'message': 'Item deleted'}

    @jwt_required()
    def put(self, name):
        data = Item.parser.parse_args()

        item = ItemModel.find_by_name(name)
        updated_item = ItemModel(name, data['price'], data['store_id'])

        if item is None: # if item is not found, insert the new item
            try:
                item = ItemModel(name, data['price'], data['store_id'])
            except:
                return {'message': 'An error occurred inserting the item'}, 500
        else: # if item exists, update item
            try:
                item.price = data['price']
            except:
                return {'message': 'An error occurred updating the item'}, 500
        item.save_to_db()
        return updated_item.json()

class ItemList(Resource):
    @jwt_required(optional=True)
    def get(self):
        user_id = get_jwt_identity()
        items = [item.json() for item in ItemModel.find_all()]
        if user_id:
            return {'items': items}, 200 # if user is logged in, return full list of items
        return { # if user is not logged in, only return item names
            'items': [item['name'] for item in items],
            'message': 'More data available if you log in'
        }, 200