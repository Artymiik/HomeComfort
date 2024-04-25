import env_setting

import Data.ApplicationDbContext as _context
from Command import command_csv

class Application(): 
  command_csv = command_csv.CommandCsv

  applications = _context.ApplicationDbContext(env_setting.connection_string, "select * from Applications")
  command_csv.create("C:\\Users\\Artemiik\\Documents\\git\\Home Comfort\\HomeComfort\\HomeComfort\\Python\\DataByDatabase\\applications.csv", applications)