import pyodbc

def ApplicationDbContext(connection_string, query):
  connection = pyodbc.connect(connection_string)

  cursor = connection.cursor()
  cursor.execute(query)

  result = cursor.fetchall()

  cursor.close()
  connection.close()

  return result