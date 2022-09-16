from tkinter import Button
from kivy.app import App
from kivy.lang import Builder
from kivy.uix.screenmanager import ScreenManager, Screen
import json, glob
from hoverable import HoverBehavior
from kivy.uix.image import Image
from kivy.uix.behaviors import ButtonBehavior
from datetime import datetime
from pathlib import Path
import random

Builder.load_file("design.kv")

class LoginScreen(Screen):
    def sign_up(self):
        self.manager.current = "sign_up_screen"

    def login(self, uname, pword):
        with open("users.json") as file:
            users = json.load(file)
        if uname in users and users[uname]["password"] == pword:
            self.manager.current = "login_screen_success"
        else:
            self.ids.login_wrong.text = "Incorrect username or password!"

class RootWidget(ScreenManager):
    pass

class SignUpScreen(Screen):
    def add_user(self, uname, pword):
        with open("users.json") as file:
            users = json.load(file)
        users[uname] = {"username": uname, "password": pword,
            "created": datetime.now().strftime("%Y-%m-%d %H-%M-%S")}

        with open("users.json", "w") as file:
            json.dump(users, file)
        
        self.manager.current = "signup_screen_success"

class SignUpScreenSuccess(Screen):
    def login_screen(self):
        self.manager.transition.direction = "right"
        self.manager.current = "login_screen"

class LoginScreenSuccess(Screen):
    def log_out(self):
        self.manager.transition.direction = "right"
        self.manager.current = "login_screen"
    
    def get_quote(self, feels):
        feels = feels.lower()
        avaialable_feels = glob.glob("quotes/*txt")

        avaialable_feels = [Path(filename).stem for filename in avaialable_feels]

        if feels in avaialable_feels:
            with open(f"quotes/{feels}.txt", encoding="utf8") as file:
                quotes = file.readlines()
            self.ids.quote.text = random.choice(quotes)
        else:
            self.ids.quote.text = "Try another feeling"

class ImageButton(ButtonBehavior, HoverBehavior, Image):
    pass

class MainApp(App):

    def build(self):
        return RootWidget()

if __name__ == "__main__":
    MainApp().run()

