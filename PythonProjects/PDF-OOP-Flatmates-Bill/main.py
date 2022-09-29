from flat import Bill, Flatmate
from reports import PdfReport

while True:
    try:
        amount = float(input("Please enter the bill amount: "))
    except ValueError:
        print("Must be a number!")
        continue
    else:
        break
period = input("Please enter the date period: i.e. March 2020 ")
name_one = input("Please enter first flatmates name: ")
while True:
    try:
        days_one = int(input(f"Please enter how many days {name_one} was in the house: "))
    except ValueError:
        print("Must be an integer!")
        continue
    else:
        break
name_two = input("Please enter second flatmates name: ")
while True:
    try:
        days_two = int(input(f"Please enter how many days {name_two} was in the house: "))
    except ValueError:
        print("Must be an integer!")
        continue
    else:
        break

the_bill = Bill(amount, period)
flatmate1 = Flatmate(name_one, days_one)
flatmate2 = Flatmate(name_two, days_two)

print(f"{flatmate1.name} pays: £{round(flatmate1.pays(the_bill, flatmate2), 2)}")
print(f"{flatmate2.name} pays: £{round(flatmate2.pays(the_bill, flatmate1), 2)}")

pdf_report = PdfReport(filename=f"Bill-{the_bill.period[:3]}-{the_bill.period[-4:]}.pdf")
pdf_report.generate(flatmate1, flatmate2, the_bill)
