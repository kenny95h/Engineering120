import webbrowser

from kivy.app import App
from kivy.lang import Builder
from kivy.uix.screenmanager import ScreenManager, Screen
from kivy.core.clipboard import Clipboard
from filesharer import FileSharer
import time

Builder.load_file("frontend.kv")


class CameraScreen(Screen):

    def start(self):
        """Starts camera"""
        self.ids.cam.play = True

    def stop(self):
        """Stops camera"""
        self.ids.cam.play = False
        self.ids.cam.texture = None

    def capture(self):
        """Creates a filename with current time and captures and saves
        a photo under that filename. Directs user to image page with that
        captured image displayed"""
        filename = time.strftime("%Y%m%d-%H%M%S")
        filepath = f"files/{filename}.png"
        self.ids.cam.export_to_png(filepath)
        self.manager.current = "image_screen"
        self.manager.current_screen.ids.img.source = filepath


class ImageScreen(Screen):

    def create_link(self):
        """Accesses photo filepath, uploads to the web,
        and inserts the link in the Label widget"""
        filepath = self.ids.img.source
        filesharer = FileSharer(filepath)
        url = filesharer.share()
        self.ids.link.text = url

    def copy_link(self):
        """Copies the web link for the image to the clipboard"""
        Clipboard.copy(self.ids.link.text)

    def open_link(self):
        """Opens the web link for the image in the web browser"""
        if self.ids.link.text == "" or self.ids.link.text == "Create a link first":
            self.ids.link.text = "Create a link first"
        else:
            webbrowser.open(self.ids.link.text)


class RootWidget(ScreenManager):
    pass


class MainApp(App):

    def build(self):
        return RootWidget()


MainApp().run()
