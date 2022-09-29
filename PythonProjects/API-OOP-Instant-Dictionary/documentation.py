import justpy as jp


class Doc:

    def serve(self):
        wp = jp.WebPage()

        div = jp.Div(a=wp, classes="bg-gray-200 h-screen p-2")
        jp.Div(a=div, text="Instant Dictionary API", classes="text-4xl m-2")
        jp.Div(a=div, text="Get definitions of words:", classes="text-lg")
        jp.Hr(a=div)
        jp.Div(a=div, text="www.example.com/api?1=rain")
        jp.Hr(a=div)
        jp.Div(a=div, text="""
        {"word": "rain",
        "definition": 
        ["Precipitation in the form of liquid water drops with diameters greater than 0.5 millimetres.",
        "To fall from the clouds in drops of water."]}
        """)

        return wp
