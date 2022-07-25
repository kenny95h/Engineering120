# Week 5: 25/07 - 29/07

**1.** [Monday](##1. Monday) - SQL

**2.** [Tuesday](##2. Tuesday) - 

**3.** [Wednesday](##3. Wednesday) - 

**4.** [Thursday](##4. Thursday) - 

**5.** [Friday](##5. Friday) - 

## 1. Monday

### SQL

* **SQL** are relational databases

* Relational Database Management Systems (RDBMS) are used to operate databases. They interpret the instructions provided by SQL

* **Data Redundancy** - repeating data within databases

* **Primary Keys** - Identifies each record in a table:
  
  * Unique identifiers
  
  * Cannot be empty
  
  * Cannot be changeable
  
  * Only one primary key per table

* **Simple primary keys** - based on a single column

* **Composite primary keys** - a combination of multiple columns

* **Foreign Keys** - used alongside primary keys to reference the relationships between tables
  
  * Point to primary keys in other tables
  
  * Makes sure connections are maintained
  
  * Do not have to be unique

* **Data modelling** has three levels, Conceptual, Logical and Physical

* **Conceptual**:
  
  * Entity names
  
  * Entity relationships

* **Logical**:
  
  * Entity names
  
  * Entity relationships
  
  * Attributes
  
  * Primary Keys
  
  * Foreign Keys

* **Physical**:
  
  * Primary Keys
  
  * Foreign Keys
  
  * Table Names
  
  * Column Names
  
  * Column Data Types

* Types of relationships:
  
  * **One to One** - One record can have a relationship with one record
  
  * **One to Many** - One record can have multiple relationships with multiple records in other tables
  
  * **Many to Many** - Many records are related to many records in other tables - Known as a **junction table**

* Entity relationship diagrams:
  
  * Represents all entities in a data model
  
  * Each entity represented by a table in the database
  
  * Each entity has attributes
  
  * Relationship shown with crows foot notation

* **Normalisation**

* First normal form:
  
  * Data must be atomic
  
  * No repeated groups
  
  * Each row must be unique

* Second normal form:
  
  * In first normal form
  
  * All non-key attributes must functionally depend upon the full primary key

* Third normal form:
  
  * In second normal form
  
  * No transitive dependencies

* Data Types:
  
  * `VARCHAR(NumBytes)` - string up to that num bytes
  
  * `CHAR(NumChars)` - string with exactly that num chars
  
  * `DATE` - Only date
  
  * `DATETIME` - Both date and time
  
  * `TIME` - Only time
  
  * `INT` - integer
  
  * `DECIMAL(precision,scale)` - max num of digits total, num of which after decimal
  
  * `FLOAT(max)`- Only need the max num of digits - not suitable for exact values
  
  * `BIT` - 1 or 0 - taken as true or false

* Create a table:
  
  * ```sql
    CREATE TABLE tablename (
        variablename DATATYPE,
        variablename DATATYPE
    );
    ```

* Insert data into table:
  
  * ```sql
    INSERT INTO tablename (
        variablename, variablename, etc
    ) VALUES (
        'character string', --VARCHAR & CHAR
        'YYYY-MM-DD 00:00:00', --DATETIME
        4, --INT
        12.74, --DOUBLE
        1.77e1, --FLOAT
        1 --BIT
    )
    ```
  
  * Insert multiple rows by adding a comma after closing bracket, and put each new row into brackets

* Remove table if exists:
  
  * ```sql
    DROP TABLE IF EXISTS tablename;
    ```

* **Null** represents a missing/unknown value, and nothing is equal to null

* Constraints are used to stop null values:
  
  * ```sql
    variablename DATATYPE NOT NULL
    ```

* A default can be used instead when no data is input, to avoid a null value:
  
  * ```sql
    variablename DATATYPE DEFAULT valueToDefaultTo
    ```

* Add primary keys:
  
  * ```sql
    variablename DATATYPE PRIMARY KEY
    ```
  
  * When entering values, each primary key must be unique and not null, otherwise it will return error

* Auto-generate primary key values:
  
  * ```sql
    variablename DATATYPE PRIMARY KEY IDENTITY (startnumber, incrementamount)
    ```

* Enforce uniqueness without requiring primary key:
  
  * ```sql
    variablename DATATYPE UNIQUE
    ```

* To add a foreign key:
  
  * ```sql
    variablename DATATYPE FOREIGN KEY REFERENCES tablename (columnname)
    ```
  
  * Only able to specify values for the foreign key that already exist in the referenced table

* To make changes to an existing table we use the `ALTER TABLE` keyword:
  
  * ```sql
    ALTER TABLE tablename
    ADD columnname DATATYPE --Add new columns
    ALTER COLUMN columnname DATATYPE --Alter datatype of existing column
    DROP COLUMN columnname --Delete column
    ```

* To view data from a table:
  
  * ```sql
    SELECT *
    FROM tablename --* means all
    ```

* To update a value use the keyword `UPDATE`:
  
  * ```sql
    UPDATE tablename
    SET variable = newValue --The new value to pass
    WHERE variable = value; --Where to update. Use primary key for one value. Common variable for multiple
    ```

* To remove rows use the `DELETE` keyword:
  
  * ```sql
    DELETE FROM tablename
    WHERE variable = value;
    ```

* There is a logical sequence for all SQL query statements:
  
  * SELECT
  
  * DISTINCT
  
  * FROM
  
  * WHERE
  
  * GROUP BY
  
  * HAVING
  
  * ORDER BY

* The processing sequence is the order in which each clause is ran:
  
  * FROM
  
  * WHERE
  
  * GROUP BY
  
  * HAVING
  
  * SELECT
  
  * DISTINCT
  
  * ORDER BY

* It is common practice to use the `AS` keyword to change the way the variable is presented:
  
  * ```sql
    SELECT variablename AS "Variable N"
    FROM tablename;
    ```

* Can combine `WHERE` statements by using the `AND`/`OR` keywords:
  
  * ```sql
    WHERE variable = value AND variabletwo > value;
    ```

* Can use wildcards to act as substitutes for characters to return values that are not exact. This is combined with the `LIKE` keyword in the `WHERE` statement:
  
  * ```sql
    WHERE variable LIKE 'Li_a'; -- starting with li and ending in a
    ```

* Can use the `%` character to substitute for 0 or more characters as specified:
  
  * ```sql
    WHERE variable LIKE 'J%'; --results with 0 or more characters after
    WHERE variable LIKE '&j%'; --results with 0 or more characters before or after
    ```

* We can specify multiple different characters by using `[]`:
  
  * ```sql
    WHERE variable LIKE 'Name [123]'; -- results includes name followed by 1, 2 0r 3
    ```

* We can also negate characters using `[^]`:
  
  * ```sql
    WHERE variable LIKE 'Name [^123]'; -- results that don't end in 1, 2 or 3
    ```

* Can make specifying a range easier by using the `BETWEEN` keyword:
  
  * ```sql
    WHERE variable BETWEEN 10 and 50;
    ```

* We can use the `IN` keyword to return rows with an entry that matches anything specified in a list:
  
  * ```sql
    WHERE variable IN ('value', 'valuetwo');
    ```

* To find `NULL` values we use the `IS` keyword:
  
  * ```sql
    WHERE variable IS NULL;
    WHERE variable IS NOT NULL;
    ```

* We can select a subset of rows by using the `TOP` keyword:
  
  * ```sql
    SELECT TOP 5 columnname;
    ```

* We can use the `ORDER BY` keyword to sort results based on columns/calculations we specify. Can sort by `ASC` or `DESC`:
  
  * ```sql
    ORDER BY variable ASC, variableTwo DESC;
    ```

* The `DISTINCT` keyword removes duplicate rows:
  
  * ```sql
    SELECT DISTINCT columnname
    ```

* We can concatenate columns or text using the character `+` or `||`:
  
  * ```sql
    SELECT variable + ' ' + variableTwo AS "Variables" -- must include an alias
    ```

* Functions:
  
  * `UPPER(text)` - uppercase
  
  * `LOWER(text)` - lowercase
  
  * `TRIM(text)` - removes spaces at end and start
  
  * `LTRIM(text)` - removes spaces from start
  
  * `RTRIM(text)` - removes spaces from end
  
  * `LENGTH(text)` - returns length of string
  
  * `LEFT(text, n)` - returns first n characters
  
  * `RIGHT(text, n)` - return last n characters
  
  * `SUBSTRING(text, start, length)` - returns characters of length from start index
  
  * `POSITION(substring IN text)` - returns index of characters or zero

* We use aggregation to reduce the number of rows, each function used will produce its own column:
  
  * ```sql
    SELECT SUM(column) AS "Total",
        AVG(column) AS "Average",
        MIN(column) AS "Minimum",
        MAX(column) AS "Maximum",
        COUNT(column) AS "Number of non-null rows"
    ```

* Date functions:
  
  * `GETDATE()` - current date
  
  * `DATEADD(unit, n, date)` - add number of specified date type to specified date
  
  * `DATEDIFF(unit, date1, date2)` - difference between dates by specified date type
  
  * `YEAR(date)` - extracts year as int
  
  * `MONTH(date)` - extracts month as int
  
  * `DAY(date)` - extracts day as int

* We can use case statements with the keywords `CASE`, `WHEN`, `THEN` and `ELSE`. We use the `END AS` keyword to give the column an alias:
  
  * ```sql
    SELECT column,
        CASE
            WHEN column < 50 THEN result
            WHEN column < 100 THEN result
            ELSE result
        END AS "Column Title"
    ```

* The `GROUP BY` keyword is used in conjunction with aggregate functions to specify a column with which to group data. Everything in the `SELECT` statement must either be an aggregate or in the `GROUP BY` statement:
  
  * ```sql
    SELECT column AS "name",
        COUNT(columnOne) AS "name one"
    FROM table
    GROUP BY column;
    ```

* Use the `HAVING` keyword to filter based on result of aggregation:
  
  * ```sql
    GROUP BY column
    HAVING AVG(column) < 100;
    ```

* The `JOIN` keyword combines tables together by matching rows and specifying a rule to join them. They are part of the `FROM` statement:
  
  * ```sql
    FROM LeftTable
    LEFT JOIN RightTable --all in left plus those in right that match
    INNER JOIN RightTable --only return matches between both
    OUTER JOIN RightTable --all in both tables
        ON LeftTable.Column = RightTable.Column
    ```

* Table aliases are used to make writing easier and quicker. Usually the initials of the table name, adding letters where match:
  
  * ```sql
    FROM table t
    JOIN othertable o
    ```

* Subqueries are queries within queries and can be used in `SELECT`, `FROM`, and `WHERE`:
  
  * ```sql
    SELECT column,
        (SELECT MAX(column) FROM table) AS "name"
    FROM table;
    ```

* We use the `UNION` keyword to join columns together vertically:
  
  * ```sql
    SELECT column AS "name"
    FROM tableOne
    UNION
    SELECT column
    FROM tableTwo;
    ```
  
  * To return a query that does not remove duplicates use the keyword `UNION ALL`

## 2. Tuesday

## 3. Wednesday

## 4. Thursday

## 5. Friday
