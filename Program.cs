using ConsoleApp12;

using var db = new EventDbContext();
db.Database.EnsureCreated();
Console.WriteLine("Database ready.");