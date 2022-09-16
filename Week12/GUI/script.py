from tkinter import *

# Instantiate window
window = Tk()

def kg_to_g():
    t1.delete(1.0,END)
    # get the value from the entry box
    grams = float(e1_value.get()) * 1000
    # insert result into text box
    t1.insert(END,f"{grams}g")

def kg_to_lb():
    t2.delete(1.0,END)
    lb = float(e1_value.get()) * 2.20462
    t2.insert(END,f"{lb}lb")

def kg_to_oz():
    t3.delete(1.0,END)
    ounce = float(e1_value.get()) * 35.274
    t3.insert(END,f"{ounce}oz")

# create widgets - link to function using command
b1 = Button(window, text="Convert", command=lambda: [kg_to_g(), kg_to_lb(), kg_to_oz()])
# position the button
b1.grid(row=0, column=2)

label = Label(window, text="Kg")
label.grid(row=0, column=0)

# create variable to get text from entry box
e1_value = StringVar()
e1 = Entry(window, textvariable=e1_value)
e1.grid(row=0, column=1)


t1 = Text(window, height=1, width=20)
t1.grid(row=1, column=0)
t2 = Text(window, height=1, width=20)
t2.grid(row=1, column=1)
t3 = Text(window, height=1, width=20)
t3.grid(row=1, column=2)

# keeps window open until pressing 'x'
window.mainloop()

