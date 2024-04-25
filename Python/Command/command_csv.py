import csv

class CommandCsv:
  def create(filePath, data):
    CommandCsv.property(data)

    with open(filePath, 'a', newline='') as file:
      for row in data:
        file.write(','.join(map(str, row)) + '\n')

  @staticmethod
  def property(data):
    if data is None:
      return "Data is required"