import sqlite3

connection = sqlite3.connect('data.db') # initialises and creates database file

cursor = connection.cursor() # allows us to select and start things in the database

create_table = "CREATE TABLE users (id int, username text, password text)" # SQL query to create table
cursor.execute(create_table) # run the query

# store data in database
user = (1, 'jose', 'asdf')
insert_query = "INSERT INTO users VALUES (?, ?, ?)" # ? are for each value we want to insert
cursor.execute(insert_query, user)

users = [
    (2, 'rolf', 'asdf'),
    (3, 'anne', 'asdf')
]

cursor.executemany(insert_query, users)

select_query = "SELECT * FROM users" # select all from users table
for row in cursor.execute(select_query): # iterates over the list of returned rows from query
    print(row)

connection.commit()

connection.close()