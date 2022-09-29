from flask.views import MethodView
from wtforms import Form, StringField, SubmitField
from flask import Flask, render_template, request
from flatmates_bill.flat import Bill, Flatmate

app = Flask(__name__)


class HomePage(MethodView):

    def get(self):
        return render_template("index.html")


class BillFormPage(MethodView):

    def get(self):
        bill_form = BillForm()
        return render_template("bill_form_page.html", bill_form=bill_form)

    def post(self):
        bill_form = BillForm(request.form)
        the_bill = Bill(float(bill_form.amount.data), bill_form.period.data)
        flatmate1 = Flatmate(bill_form.name1.data, float(bill_form.days_in_house1.data), )
        flatmate2 = Flatmate(bill_form.name2.data, float(bill_form.days_in_house2.data), )
        return render_template("bill_form_page.html", result=True, bill_form=bill_form, name1=flatmate1.name,
                               amount1=round(flatmate1.pays(the_bill, flatmate2), 2),
                               name2=flatmate2.name, amount2=round(flatmate2.pays(the_bill, flatmate1), 2))


class ResultsPage(MethodView):

    def post(self):
        bill_form = BillForm(request.form)
        the_bill = Bill(float(bill_form.amount.data), bill_form.period.data)
        flatmate1 = Flatmate(bill_form.name1.data, float(bill_form.days_in_house1.data), )
        flatmate2 = Flatmate(bill_form.name2.data, float(bill_form.days_in_house2.data), )
        return render_template("results.html", name1=flatmate1.name, amount1=round(flatmate1.pays(the_bill, flatmate2), 2),
                               name2=flatmate2.name, amount2=round(flatmate2.pays(the_bill, flatmate1), 2))


class BillForm(Form):
    amount = StringField("Bill Amount: ", default="100")
    period = StringField("Bill Period: ", default="December 2020")

    name1 = StringField("Name: ", default="John")
    days_in_house1 = StringField("Days in the house: ", default="30")

    name2 = StringField("Name: ", default="Jane")
    days_in_house2 = StringField("Days in the house: ", default="30")

    button = SubmitField("Calculate")


app.add_url_rule("/", view_func=HomePage.as_view("home_page"))
app.add_url_rule("/bill_form", view_func=BillFormPage.as_view("bill_form_page"))
#app.add_url_rule("/results", view_func=ResultsPage.as_view("results_page"))
app.run()
