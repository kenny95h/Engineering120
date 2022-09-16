"""
A program that stores book information:
Title, Author
Year, ISBN

User can:
View all records
Search an entry
Add entry
Update entry
Delete
Close
"""

from tkinter import *
from backend import Database

database = Database("books.db")

def get_selected_row(event):
    try:
        global selected_tuple
        index = lb.curselection()[0]
        selected_tuple = lb.get(index)
        etitle.delete(0,END)
        etitle.insert(END, selected_tuple[1])
        eauthor.delete(0,END)
        eauthor.insert(END, selected_tuple[2])
        eyear.delete(0,END)
        eyear.insert(END, selected_tuple[3])
        eisbn.delete(0,END)
        eisbn.insert(END, selected_tuple[4])
    except:
        pass

def view_command():
    lb.delete(0,END)
    for row in database.view():
        lb.insert(END, row)

def search_command():
    lb.delete(0,END)
    for row in database.search(etitle_value.get(), eauthor_value.get(), eyear_value.get(), eisbn_value.get()):
        lb.insert(END,row)

def add_command():
    database.insert(etitle_value.get(), eauthor_value.get(), eyear_value.get(), eisbn_value.get())
    lb.delete(0,END)
    lb.insert(END,(etitle_value.get(), eauthor_value.get(), eyear_value.get(), eisbn_value.get()))

def delete_command():
    database.delete(selected_tuple[0])
    view_command()

def update_command():
    database.update(selected_tuple[0], etitle_value.get(), eauthor_value.get(), eyear_value.get(), eisbn_value.get())
    view_command()

# Instantiate window
window = Tk()
window.wm_title("Book Store")

# create buttons
bview = Button(window, text="View All", width=12, command=view_command)
bview.grid(row=2, column=3)

bsearch = Button(window, text="Search entry", width=12, command=search_command)
bsearch.grid(row=3, column=3)

badd = Button(window, text="Add entry", width=12, command=add_command)
badd.grid(row=4, column=3)

bupdate = Button(window, text="Update Selected", width=12, command=update_command)
bupdate.grid(row=5, column=3)

bdelete = Button(window, text="Delete Selected", width=12, command=delete_command)
bdelete.grid(row=6, column=3)

bclose = Button(window, text="Close", width=12, command=window.destroy)
bclose.grid(row=7, column=3)

# create labels
title_label = Label(window, text="Title")
title_label.grid(row=0, column=0)

year_label = Label(window, text="Year")
year_label.grid(row=1, column=0)

author_label = Label(window, text="Author")
author_label.grid(row=0, column=2)

isbn_label = Label(window, text="ISBN")
isbn_label.grid(row=1, column=2)

# create text entry boxes
etitle_value = StringVar()
etitle = Entry(window, textvariable=etitle_value)
etitle.grid(row=0, column=1)

eyear_value = StringVar()
eyear = Entry(window, textvariable=eyear_value)
eyear.grid(row=1, column=1)

eauthor_value = StringVar()
eauthor = Entry(window, textvariable=eauthor_value)
eauthor.grid(row=0, column=3)

eisbn_value = StringVar()
eisbn = Entry(window, textvariable=eisbn_value)
eisbn.grid(row=1, column=3)

# create listbox
lb = Listbox(window, height=6, width=35)
lb.grid(row=2, column=0, rowspan=6, columnspan=2)

# create scrollbar
sb = Scrollbar(window)
sb.grid(row=2, column=2, rowspan=6)

# configure scrollbar to scroll listbox
lb.configure(yscrollcommand=sb.set)
sb.configure(command=lb.yview)

# link list box to method to return values of selected row
lb.bind("<<ListboxSelect>>", get_selected_row)

# keeps window open until pressing 'x'
window.mainloop()

