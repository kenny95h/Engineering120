import justpy as jp
import definition
from webapp import layout, page
import requests


class Dictionary(page.Page):
    path = "/dictionary"

    @classmethod
    def serve(cls, req):
        wp = jp.QuasarPage(tailwind=True)

        lay = layout.DefaultLayout(a=wp)
        container = jp.QPageContainer(a=lay)

        div = jp.Div(a=container, classes="bg-gray-200 h-screen p-2")
        jp.Div(a=div, text="Instant English Dictionary", classes="text-4xl m-2")
        jp.Div(a=div, text="Get the definition of any English word instantly as you type.", classes="text-lg")

        input_div = jp.Div(a=div, classes="grid grid-cols-2")
        output_div = jp.Div(a=div, classes="m-2 p-2 text-lg border-2 border-gray-300 h-40")
        input_box = jp.Input(a=input_div, placeholder="Type a word in here...", outputdiv=output_div,
                             classes="m-2 bg-gray-100 border-2 border-gray-200 rounded w-64 focus:outline-none "
                                     "focus:border-purple-500 py-2 px-4")
        input_box.on("input", cls.get_definition)
        # jp.Button(a=input_div, text="Get Definition", classes="border-2 border-gray-300 text-gray-500",
        #           click=cls.get_definition, outputdiv=output_div, inputbox=input_box)

        return wp

    @staticmethod
    def get_definition(widget, msg):
        defined = definition.Definition(widget.value).get()
        widget.outputdiv.text = " ".join(defined)

        # Get from API
        # req = requests.get(f"http://127.0.0.1:8000/api?w={widget.value}")
        # data = req.json()
        # widget.outputdiv.text = " ".join(data["definition"])
