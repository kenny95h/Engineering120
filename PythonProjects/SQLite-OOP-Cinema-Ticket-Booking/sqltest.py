import sqlite3


def create_table():
    conn = sqlite3.connect("cinema.db")
    conn.execute("""
                CREATE TABLE IF NOT EXISTS "Seat"(
                    "seat_id" TEXT,
                    "taken" INTEGER,
                    "price" REAL
                );
                """)
    conn.commit()
    conn.close()


def insert_record():
    conn = sqlite3.connect("cinema.db")
    conn.execute("""
    INSERT INTO "Seat" ("seat_id", "taken", "price") VALUES ("A1", "0", "90"), ("A2", "1", "100"), ("A3", "0", "80")
    """)
    conn.commit()
    conn.close()


def select_all():
    conn = sqlite3.connect("cinema.db")
    cur = conn.cursor()
    cur.execute("""
    SELECT * FROM "Seat"
    """)
    result = cur.fetchall()
    conn.close()
    return result

def select_all_card():
    conn = sqlite3.connect("banking.db")
    cur = conn.cursor()
    cur.execute("""
    SELECT * FROM "Card"
    """)
    result = cur.fetchall()
    conn.close()
    return result


def select_specific_columns():
    conn = sqlite3.connect("cinema.db")
    cur = conn.cursor()
    cur.execute("""
        SELECT "seat_id", "price" FROM "Seat"
        """)
    result = cur.fetchall()
    conn.close()
    return result

def select_with_ccondition():
    conn = sqlite3.connect("cinema.db")
    cur = conn.cursor()
    cur.execute("""
        SELECT "seat_id", "price" FROM "Seat" WHERE "price" > 100
        """)
    result = cur.fetchall()
    conn.close()
    return result


def update_value(occupied, seat_id):
    conn = sqlite3.connect("cinema.db")
    conn.execute("""
        UPDATE "Seat" SET "taken" = ? WHERE "seat_id" = ?
        """, [occupied, seat_id])
    conn.commit()
    conn.close()

def update_card_value(balance):
    conn = sqlite3.connect("banking.db")
    conn.execute("""
        UPDATE "Card" SET "balance" = ? WHERE "number" = "12345678"
        """, [balance])
    conn.commit()
    conn.close()


def delete_record():
    conn = sqlite3.connect("cinema.db")
    conn.execute("""
            DELETE FROM "Seat" WHERE "seat_id" = "B3"
            """)
    conn.commit()
    conn.close()


update_value(0, "A1")
print(select_all())

update_card_value(4400)
print(select_all_card())
