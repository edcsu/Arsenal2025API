using Arsenal2025API.Models;

namespace Arsenal2025API.Data;

public static class SeedData
{
    public static List<Player> PlayerList()
    {
        List<Player> players = 
        [
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow),
                Name = "David Raya",
                Position = Position.Goalkeeper,
                Country = "Spain",
                CleanSheets = 16,
                GoalsScored = 0,
                Assists = 0,
                DateOfBirth = new DateOnly(1995, 09, 15),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(1)),
                Name = "Neto",
                Position = Position.Goalkeeper,
                Country = "Brazil",
                CleanSheets = 1,
                GoalsScored = 0,
                Assists = 0,
                DateOfBirth = new DateOnly(1989, 7, 19),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(2)),
                Name = "William Saliba",
                Position = Position.CentreBack,
                Country = "France",
                CleanSheets = 18,
                GoalsScored = 2,
                Assists = 1,
                DateOfBirth = new DateOnly(2001, 3, 24),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(3)),
                Name = "Gabriel Magalhães",
                Position = Position.CentreBack,
                Country = "Brazil",
                CleanSheets = 17,
                GoalsScored = 4,
                Assists = 0,
                DateOfBirth = new DateOnly(1997, 12, 19),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(4)),
                Name = "Jakub Kiwior",
                Position = Position.CentreBack,
                Country = "Poland",
                CleanSheets = 8,
                GoalsScored = 1,
                Assists = 0,
                DateOfBirth = new DateOnly(2000, 2, 15),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(5)),
                Name = "Riccardo Calafiori",
                Position = Position.LeftBack,
                Country = "Italy",
                CleanSheets = 0,
                GoalsScored = 0,
                Assists = 0,
                DateOfBirth = new DateOnly(2002, 5, 19),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(6)),
                Name = "Myles Lewis-Skelly",
                Position = Position.LeftBack,
                Country = "England",
                CleanSheets = 0,
                GoalsScored = 0,
                Assists = 0,
                DateOfBirth = new DateOnly(2006, 9, 26),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(7)),
                Name = "Oleksandr Zinchenko",
                Position = Position.LeftBack,
                Country = "Ukraine",
                CleanSheets = 10,
                GoalsScored = 1,
                Assists = 2,
                DateOfBirth = new DateOnly(1996, 12, 15),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(8)),
                Name = "Kieran Tierney",
                Position = Position.LeftBack,
                Country = "Scotland",
                CleanSheets = 2,
                GoalsScored = 0,
                Assists = 0,
                DateOfBirth = new DateOnly(1997, 6, 5),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(9)),
                Name = "Ben White",
                Position = Position.RightBack,
                Country = "England",
                CleanSheets = 15,
                GoalsScored = 0,
                Assists = 4,
                DateOfBirth = new DateOnly(1997, 10, 08),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(10)),
                Name = "Jurrien Timber",
                Position = Position.RightBack,
                Country = "Netherlands",
                CleanSheets = 1,
                GoalsScored = 0,
                Assists = 0,
                DateOfBirth = new DateOnly(2001, 6, 17),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(11)),
                Name = "Takehiro Tomiyasu",
                Position = Position.RightBack,
                Country = "Japan",
                CleanSheets = 12,
                GoalsScored = 0,
                Assists = 1,
                DateOfBirth = new DateOnly(1998, 11, 5),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(12)),
                Name = "Thomas Partey",
                Position = Position.DefensiveMidfielder,
                Country = "Ghana",
                CleanSheets = 7,
                GoalsScored = 0,
                Assists = 0,
                DateOfBirth = new DateOnly(1993, 6, 13),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(13)),
                Name = "Jorginho",
                Position = Position.DefensiveMidfielder,
                Country = "Italy",
                CleanSheets = 9,
                GoalsScored = 0,
                Assists = 1,
                DateOfBirth = new DateOnly(1991, 12, 20),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(14)),
                Name = "Declan Rice",
                Position = Position.CentralMidfielder,
                Country = "England",
                CleanSheets = 16,
                GoalsScored = 7,
                Assists = 6,
                DateOfBirth = new DateOnly(1999, 1, 14),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(15)),
                Name = "Mikel Merino",
                Position = Position.CentralMidfielder,
                Country = "Spain",
                CleanSheets = 0,
                GoalsScored = 0,
                Assists = 0,
                DateOfBirth = new DateOnly(1996, 6, 22),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(16)),
                Name = "Martin Ødegaard",
                Position = Position.AttackingMidfielder,
                Country = "Norway",
                CleanSheets = 15,
                GoalsScored = 11,
                Assists = 11,
                DateOfBirth = new DateOnly(1998, 12, 17),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(17)),
                Name = "Gabriel Martinelli",
                Position = Position.LeftWinger,
                Country = "Brazil",
                CleanSheets = 13,
                GoalsScored = 8,
                Assists = 5,
                DateOfBirth = new DateOnly(2001, 6, 18),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(18)),
                Name = "Leandro Trossard",
                Position = Position.LeftWinger,
                Country = "Belgium",
                CleanSheets = 11,
                GoalsScored = 12,
                Assists = 7,
                DateOfBirth = new DateOnly(1994, 12, 4),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(19)),
                Name = "Bukayo Saka",
                Position = Position.RightWinger,
                Country = "England",
                CleanSheets = 15,
                GoalsScored = 20,
                Assists = 13,
                DateOfBirth = new DateOnly(2001, 9, 5),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(20)),
                Name = "Ethan Nwaneri",
                Position = Position.RightWinger,
                Country = "England",
                CleanSheets = 0,
                GoalsScored = 0,
                Assists = 0,
                DateOfBirth = new DateOnly(2007, 3, 21),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(21)),
                Name = "Raheem Sterling",
                Position = Position.RightWinger,
                Country = "England",
                CleanSheets = 0,
                GoalsScored = 0,
                Assists = 0,
                DateOfBirth = new DateOnly(1994, 12, 8),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(22)),
                Name = "Kai Havertz",
                Position = Position.Striker,
                Country = "Germany",
                CleanSheets = 14,
                GoalsScored = 14,
                Assists = 7,
                DateOfBirth = new DateOnly(1999, 6, 11),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(23)),
                Name = "Gabriel Jesus",
                Position = Position.Striker,
                Country = "Brazil",
                CleanSheets = 12,
                GoalsScored = 5,
                Assists = 5,
                DateOfBirth = new DateOnly(1997, 4, 3),
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            }
        ];
        return players;
    }

    public static List<Coach> CoachList()
    {
        List<Coach> coaches =
        [
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow),
                Name = "Mikel Arteta",
                TotalTrophies = 2,
                Tenure = "2019 – present",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(1)),
                Name = "Freddie Ljungberg",
                TotalTrophies = 0,
                Tenure = "2019 (interim)",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(2)),
                Name = "Unai Emery",
                TotalTrophies = 0,
                Tenure = "2018 – 2019",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(3)),
                Name = "Pat Rice",
                TotalTrophies = 0,
                Tenure = "1996 (caretaker)"
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(4)),
                Name = "Bruce Rioch",
                TotalTrophies = 0,
                Tenure = "1995 – 1996",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(5)),
                Name = "Stewart Houston",
                TotalTrophies = 0,
                Tenure = "1995 (caretaker)",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(6)),
                Name = "George Graham",
                TotalTrophies = 6,
                Tenure = "1986 – 1995",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(7)),
                Name = "Steve Burtenshaw",
                TotalTrophies = 0,
                Tenure = "1986 (caretaker)",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(8)),
                Name = "Don Howe",
                TotalTrophies = 0,
                Tenure = "1983 – 1986",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(9)),
                Name = "Terry Neill",
                TotalTrophies = 1,
                Tenure = "1976 – 1983",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(10)),
                Name = "Bertie Mee",
                TotalTrophies = 3,
                Tenure = "1966 – 1976",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(11)),
                Name = "Billy Wright",
                TotalTrophies = 0,
                Tenure = "1962 – 1966",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(12)),
                Name = "George Swindin",
                TotalTrophies = 0,
                Tenure = "1958 – 1962",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(13)),
                Name = "Jack Crayston",
                TotalTrophies = 0,
                Tenure = "1956 – 1958",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(14)),
                Name = "Tom Whittaker",
                TotalTrophies = 5,
                Tenure = "1947 – 1956",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(15)),
                Name = "George Allison",
                TotalTrophies = 4,
                Tenure = "1934 – 1947",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(16)),
                Name = "Herbert Chapman",
                TotalTrophies = 6,
                Tenure = "1925 – 1934",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(17)),
                Name = "Leslie Knighton",
                TotalTrophies = 0,
                Tenure = "1919 – 1925",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(18)),
                Name = "George Morrell",
                TotalTrophies = 0,
                Tenure = "1908 – 1915",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(19)),
                Name = "Phil Kelso",
                TotalTrophies = 0,
                Tenure = "1904 – 1908",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
            new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(20)),
                Name = "Harry Bradshaw",
                TotalTrophies = 0,
                Tenure = "1899 – 1904",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(21)),
                Name = "Thomas Mitchell",
                TotalTrophies = 0,
                Tenure = "1897 – 1899",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },new ()
            {
                Id = Guid.CreateVersion7(DateTimeOffset.UtcNow.AddSeconds(22)),
                Name = "Sam Hollis",
                TotalTrophies = 0,
                Tenure = "1895 – 1897",
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
            },
        ];

        return coaches;
    }
}