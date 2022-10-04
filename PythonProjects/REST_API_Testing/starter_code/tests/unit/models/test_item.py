from unittest import TestCase
from starter_code.models.item import ItemModel


class ItemTest(TestCase):
    def test_create_item(self):
        # create an instance of the item model
        item = ItemModel("test", 19.99)

        # check both variables have been instantiated as expected
        self.assertEqual(item.name, "test")
        self.assertEqual(item.price, 19.99)

    def test_item_json(self):
        item = ItemModel("test", 19.99)

        # the expected json item from calling the method
        expected = {
            "name": "test",
            "price": 19.99
        }

        # check the json method returns the item as a dictionary
        self.assertEqual(item.json(), expected)