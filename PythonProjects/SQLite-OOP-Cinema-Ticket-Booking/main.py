import string
from random import random
import sqlite3

from fpdf import FPDF


class User:
    """Represents a user that can buy a cinema ticket"""

    def __init__(self, name):
        self.name = name

    def buy(self, seat, card):
        """Buys cinema ticket if card is valid -
        Updates seat to occupied and deducts price form card"""
        if not seat.is_free():
            return "Seat is taken!"
        buy_ticket = card.validate(seat.get_price())
        if isinstance(buy_ticket, float):
            seat.occupy()
            ticket = Ticket(self, seat.get_price(), seat.seat_id)
            ticket.to_pdf()
            return f"Ticket {seat.seat_id} purchased successfully"
        else:
            return buy_ticket


class Seat:

    database = "cinema.db"

    def __init__(self, seat_id):
        self.seat_id = seat_id

    def get_price(self):
        """Returns the price of the specified seat"""
        conn = sqlite3.connect(self.database)
        cur = conn.cursor()
        cur.execute("""
        SELECT "price" FROM "Seat" WHERE "seat_id" = ?
        """, [self.seat_id])
        price = cur.fetchone()[0]
        conn.close()
        return price

    def is_free(self):
        """Returns if the specified seat is occupied or not"""
        conn = sqlite3.connect(self.database)
        cur = conn.cursor()
        cur.execute("""
        SELECT "taken" FROM "Seat" WHERE "seat_id" = ?
        """, [self.seat_id])
        free = cur.fetchone()[0]
        conn.close()
        return True if free == 0 else False

    def occupy(self):
        """Updates the database for the specified seat to being occupied"""
        conn = sqlite3.connect(self.database)
        conn.execute("""
                UPDATE "Seat" SET "taken" = 1 WHERE "seat_id" = ?
                """, [self.seat_id])
        conn.commit()
        conn.close()


class Card:

    database = "banking.db"

    def __init__(self, card_type, number, cvc, holder):
        self.card_type = card_type
        self.number = number
        self.cvc = cvc
        self.holder = holder

    def validate(self, price):
        """Confirms card is in database and deducts amount off total"""
        conn = sqlite3.connect(self.database)
        cur = conn.cursor()
        cur.execute("""
                        SELECT "balance" FROM "Card" WHERE "number" = ? AND "cvc" = ? AND "holder" = ?
                        """, [self.number, self.cvc, self.holder])
        card = cur.fetchone()
        if card is not None:
            card = card[0]
            if card >= price:
                conn.execute("""
                UPDATE "Card" SET "balance" = ? WHERE "number" = ?
                """, [card - price, self.number])
                conn.commit()
                conn.close()
                return card - price
            conn.close()
            return "Insufficient funds available"
        conn.close()
        return "Incorrect card details"


class Ticket:

    def __init__(self, user, price, seat_number):
        self.user = user
        self.price = price
        self.id = "".join([random.choice(string.ascii_letters) for i in range(8)])
        self.seat_number = seat_number

    def to_pdf(self):
        """Creates a PDF  ticket"""
        pdf = FPDF(orientation="P", unit="pt", format="A4")
        pdf.add_page()

        pdf.set_font(family="Times", style="B", size=24)
        pdf.cell(w=0, h=80, txt="Your Digital Cinema Ticket", border=1, ln=1, align="C")

        pdf.set_font(family="Times", style="B", size=14)
        pdf.cell(w=100, h=25, txt="Name: ", border=1)
        pdf.set_font(family="Times", style="", size=12)
        pdf.cell(w=0, h=25, txt=self.user.name, border=1, ln=1)
        pdf.cell(w=0, h=5, txt="", border=0, ln=1)

        pdf.set_font(family="Times", style="B", size=14)
        pdf.cell(w=100, h=25, txt="Ticket ID: ", border=1)
        pdf.set_font(family="Times", style="", size=12)
        pdf.cell(w=0, h=25, txt=self.id, border=1, ln=1)
        pdf.cell(w=0, h=5, txt="", border=0, ln=1)

        pdf.set_font(family="Times", style="B", size=14)
        pdf.cell(w=100, h=25, txt="Price: ", border=1)
        pdf.set_font(family="Times", style="", size=12)
        pdf.cell(w=0, h=25, txt=str(self.price), border=1, ln=1)
        pdf.cell(w=0, h=5, txt="", border=0, ln=1)

        pdf.set_font(family="Times", style="B", size=14)
        pdf.cell(w=100, h=25, txt="Seat Number: ", border=1)
        pdf.set_font(family="Times", style="", size=12)
        pdf.cell(w=0, h=25, txt=str(self.seat_number), border=1, ln=1)
        pdf.cell(w=0, h=5, txt="", border=0, ln=1)

        pdf.output("sample.pdf", "F")


if __name__ == "__main__":
    user = User(input("Please input your name: "))
    seat = Seat(input("Please input your preferred seat: "))
    card_type = input("PLease input your card type: (Visa/Mastercard) ")
    card_num = input("Please input your 8 digit card number: ")
    card_cvc = input("Please input your 3 digit cvc from back of the card: ")
    card_holder = input("Please input the full name of the card holder: ").title()
    user_card = Card(card_type, card_num, card_cvc, card_holder)
    print(user.buy(seat, user_card))
