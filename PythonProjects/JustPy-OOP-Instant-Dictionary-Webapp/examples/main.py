import justpy as jp

@jp.SetRoute("/")
def home():
    wp = jp.QuasarPage(tailwind=True)
    div = jp.Div(a=wp, classes="bg-gray-200 h-screen")

    div1 = jp.Div(a=div, classes="grid grid-cols-3 gap-2 p-4")
    in_1 = jp.Input(a=div1, placeholder="Enter first value", classes="form-input")
    in_2 = jp.Input(a=div1, placeholder="Enter second value", classes="form-input")
    d_output = jp.Div(a=div1, text="Result goes here...", classes="text-gray-600")
    jp.Div(a=div1, text="And another one...", classes="text-gray-600")
    jp.Div(a=div1, text="One more time...", classes="text-gray-600")

    div2 = jp.Div(a=div, classes="grid grid-cols-2 gap-4")
    jp.QButton(a=div2, color="secondary", label="Calculate", click=sum_up, in1=in_1, in2=in_2, d=d_output)
    jp.Div(a=div2, text="This time I am interactive...", mouseenter=mouse_enter, mouseleave=mouse_leave,
           lasses="hover:text-red")

    return wp


def sum_up(widget, msg):
    result = float(widget.in1.value) + float(widget.in2.value)
    widget.d.text = result


def mouse_enter(widget, msg):
    widget.text = "A mouse has appeared"


def mouse_leave(widget, msg):
    widget.text = "A mouse has now left"


jp.justpy()
