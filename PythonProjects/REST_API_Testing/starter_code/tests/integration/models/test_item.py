from starter_code.models.item import ItemModel
from starter_code.tests.base_test import BaseTest


class ItemTest(BaseTest):
    def test_crud(self):
        with self.app_context(): # calls the setup of the app from the base test
            item = ItemModel('test', 19.99)

            self.assertIsNone(ItemModel.find_by_name('test')) # check item does not exist before adding to db

            item.save_to_db() # calls method to save item to db

            self.assertIsNotNone(ItemModel.find_by_name('test')) # checks db can find new item.