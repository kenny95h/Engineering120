import webbrowser
from fpdf import FPDF
import os


class PdfReport:
    """
    Creates a PDF file that contains data about the flatmates
    such as their names, their due amount and the period of
    the bill
    """

    def __init__(self, filename):
        self.filename = filename

    def generate(self, flatmate1, flatmate2, bill):

        flatmate1_pay = round(flatmate1.pays(bill, flatmate2), 2)
        flatmate2_pay = round(flatmate2.pays(bill, flatmate1), 2)

        # Instantiate PDF object
        pdf = FPDF(orientation="P", unit="pt", format="A4")
        pdf.add_page()

        # Add image icon
        pdf.image("files/house.png", w=30, h=30)

        # Add title
        pdf.set_font(family="Times", size=24, style="B")
        pdf.cell(w=0, h=80, txt="Flatmates Bill", border=0, align="C", ln=1)
        # Add period
        pdf.set_font(family="Times", size=14, style="B")
        pdf.cell(w=100, h=40, txt="Period:", border=0)
        pdf.cell(w=150, h=40, txt=bill.period, border=0, ln=1)
        # Add first flatmate bill
        pdf.set_font(family="Times", size=12)
        pdf.cell(w=150, h=25, txt=f"{flatmate1.name}: ", border=0)
        pdf.cell(w=150, h=25, txt=f"£{flatmate1_pay} ", border=0, ln=1)
        # Add second flatmate bill
        pdf.cell(w=150, h=25, txt=f"{flatmate2.name}: ", border=0)
        pdf.cell(w=150, h=25, txt=f"£{flatmate2_pay} ", border=0, ln=1)
        # create pdf file
        os.chdir("files")
        pdf.output(self.filename)

        # open pdf file in browser
        webbrowser.open(self.filename)
