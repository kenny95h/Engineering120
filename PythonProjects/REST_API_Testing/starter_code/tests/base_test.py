'''
BaseTest

This class should be the parent class to each non-unit test.
It allows for instantiation of the database dynamically
and makes sure that it is a new, blank database each time.
'''

from unittest import TestCase
from starter_code.app import app
# need to import db initialise the tables
from starter_code.db import db


class BaseTest(TestCase):
    # runs before every test
    def setUp(self):
        # Make sure database exists
        app.config['SQLALCHEMY_DATABASE_URI'] = "sqlite:///" # sets a config file in the app, and creates a blank db file using sqlite
        with app.app_context():
            db.init_app(app)
            db.create_all()
        # Get a test client
        self.app = app.test_client()
        # allows  us to access the app context later in the tests
        self.app_context = app.app_context

    # runs after every test
    def tearDown(self):
        # Database is blank
        with app.app_context():
            db.session.remove()
            db.drop_all()