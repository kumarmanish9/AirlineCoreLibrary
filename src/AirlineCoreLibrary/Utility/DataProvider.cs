namespace AirlineCoreLibrary.Utility
{
    internal static class DataProvider
    {
        public static string[] FirstNames = [
               "John", "Jane", "Robert", "Karen", "Emily", "Michael", "Sarah", "David", "Jessica", "Daniel",
                "Sophia", "Emma", "Olivia", "Ava", "Isabella", "Mia", "Charlotte", "Amelia", "Harper", "Evelyn",
                "Liam", "Noah", "Oliver", "Elijah", "James", "William", "Benjamin", "Lucas", "Henry", "Alexander",
                "Jackson", "Logan", "Mason", "Ethan", "Jacob", "Sebastian", "Jack", "Aiden", "Matthew", "Samuel",
                "Chloe", "Ella", "Grace", "Victoria", "Scarlett", "Zoey", "Hannah", "Lily", "Aria", "Ellie",
                "Ryan", "Nathan", "Carter", "Luke", "Isaac", "Gabriel", "Anthony", "Dylan", "Leo", "Caleb",
                "Layla", "Sofia", "Abigail", "Avery", "Elizabeth", "Nora", "Addison", "Madison", "Audrey", "Bella",
                "Hunter", "Wyatt", "Jayden", "Eli", "Ezra", "Grayson", "Connor", "Aaron", "Christian", "Jonathan",
                "Paisley", "Peyton", "Aubrey", "Stella", "Natalie", "Mila", "Riley", "Kinsley", "Brooklyn", "Hazel",
                "Eleanor", "Lucy", "Savannah", "Caroline", "Maya", "Autumn", "Piper", "Quinn", "Violet", "Naomi",
                "Alexis", "Sadie", "Claire", "Anna", "Serenity", "Ariana", "Allison", "Gabriella", "Alice", "Genesis",
                "Jordan", "Cameron", "Parker", "Evan", "Adam", "Dominic", "Nolan", "Austin", "Carson", "Elliot",
                "Julian", "Brayden", "Ryder", "Silas", "Hudson", "Micah", "Vincent", "Miles", "Colton", "Weston",
                "Luna", "Camila", "Willow", "Everly", "Ivy", "Aurora", "Zoie", "Rose", "Lillian", "Eva",
                "Katherine", "Reagan", "Maria", "Lila", "Bailey", "Skylar", "Valeria", "Adalyn", "Jade", "Summer",
                "Maxwell", "Oscar", "Theo", "Jason", "Roman", "Asher", "Harrison", "Kai", "Zachary", "Malachi",
                "Angel", "Blake", "Bentley", "Calvin", "Bennett", "Beau", "Greyson", "Ezekiel", "Gavin", "Caden",
                "Rory", "Finn", "Declan", "Tucker", "Anderson", "Griffin", "Maddox", "Sullivan", "Archer", "Jaxon",
                "Kaden", "Jasper", "Emmett", "Rylan", "Xavier", "Spencer", "Bryson", "Walker", "Hayden", "Easton",
                "Aspen", "Dakota", "London", "Juniper", "Rowan", "Phoenix", "Sage", "Arden", "Emery", "Blair",
                "Amara", "Callie", "Freya", "Thea", "Elsie", "Fiona", "Wren", "Meadow", "Mira", "Sienna",
                "Daisy", "Delilah", "Brielle", "Ayla", "Nova", "Eliza", "Gia", "Lana", "Cleo", "Mabel",
                "Reed", "Brandon", "Cody", "Landon", "Tyler", "Trevor", "Chase", "Bryce", "Jared", "Shawn",
                "Travis", "Clayton", "Brady", "Shane", "Colby", "Casey", "Brice", "Derek", "Corey", "Grant",
                "Hope", "Faith", "Charity", "Joy", "Grace", "Mercy", "Harmony", "Destiny", "Trinity", "Patience",
                "Aiden", "Zane", "Cruz", "Brooks", "Rhett", "Cash", "Knox", "Crew", "Reid", "Bo",
                "Penelope", "Tessa", "Molly", "Zara", "Isla", "Macy", "Josie", "Harlow", "Oakley", "Skyler",
                "Alina", "Cecilia", "Poppy", "Makenna", "Ariella", "Esme", "Leilani", "Lucia", "Alaina", "Emilia",
                "Dakota", "Sterling", "Carter", "Ashton", "Harley", "Flynn", "Denver", "Rowan", "Skyler", "Justice",
                "Micah", "Quincy", "Elliott", "Tanner", "Drew", "Sawyer", "Dallas", "Peyton", "Reese", "Ellis",
                "Aspen", "Emerson", "Monroe", "Rory", "Tate", "Jules", "Quinn", "Merritt", "River", "Shiloh",
            ];

        public static string[] LastNames = [
                "Anderson", "Miller", "Davis", "Wilson", "Moore", "Thomas", "White", "Jackson", "Harris", "Martin",
                "Thompson", "Martins", "Clark", "Lopez", "Allen", "King", "Wright", "Scott", "Green", "Adams",
                "Baker", "Gonzalez", "Nelson", "Carter", "Mitchell", "Perez", "Roberts", "Phillips", "Evans", "Turner",
                "Campbell", "Parker", "Edwards", "Collins", "Stewart", "Sanchez", "Morris", "Rogers", "Reed", "Cook",
                "Morgan", "Bell", "Murphy", "Bailey", "Rivera", "Cooper", "Richardson", "Cox", "Howard", "Ward",
                "Torres", "Peterson", "Gray", "Ramirez", "James", "Watson", "Brooks", "Kelly", "Sanders", "Price",
                "Bennett", "Wood", "Barnes", "Ross", "Henderson", "Coleman", "Jenkins", "Perry", "Powell", "Long",
                "Patterson", "Hughes", "Flores", "Washington", "Butler", "Simmons", "Foster", "Gonzales", "Bryant", "Alexander",
                "Russell", "Griffin", "Diaz", "Hayes", "Myers", "Ford", "Hamilton", "Graham", "Sullivan", "Wallace",
                "Woods", "West", "Jordan", "Owens", "Fisher", "Ellis", "Harrison", "Gibson", "Mcdonald", "Cruz",
                "Marshall", "Ortiz", "Gomez", "Murray", "Freeman", "Wells", "Webb", "Simpson", "Stevens", "Tucker",
                "Porter", "Hunter", "Hicks", "Crawford", "Henry", "Boyd", "Mason", "Morales", "Kennedy", "Warren",
                "Dixon", "Ramos", "Reyes", "Burns", "Gordon", "Shaw", "Holmes", "Rice", "Robertson", "Hunt",
                "Black", "Daniels", "Palmer", "Mills", "Nichols", "Grant", "Knight", "Ferguson", "Rose", "Stone",
                "Hawkins", "Dunn", "Perkins", "Hudson", "Spencer", "Gardner", "Stephens", "Payne", "Pierce", "Berry",
                "Matthews", "Arnold", "Wagner", "Willis", "Ray", "Watkins", "Olson", "Carroll", "Duncan", "Snyder",
                "Hart", "Cunningham", "Bradley", "Lane", "Andrews", "Ruiz", "Harper", "Fox", "Riley", "Armstrong",
                "Carpenter", "Weaver", "Greene", "Lawrence", "Elliott", "Chavez", "Sims", "Austin", "Peters", "Kelley",
                "Franklin", "Lawson", "Fields", "Gutierrez", "Ryan", "Schmidt", "Carr", "Vasquez", "Castillo", "Wheeler",
                "Chapman", "Oliver", "Montgomery", "Richards", "Williamson", "Johnston", "Banks", "Meyer", "Bishop", "McCoy",
                "Howell", "Alvarez", "Morrison", "Hansen", "Fernandez", "Garza", "Harvey", "Little", "Burton", "Stanley",
                "Nguyen", "George", "Jacobs", "Reid", "Kim", "Fuller", "Lynch", "Dean", "Gilbert", "Garrett",
                "Romero", "Welch", "Larson", "Frazier", "Burke", "Hanson", "Day", "Mendoza", "Moreno", "Bowman",
                "Medina", "Fowler", "Brewer", "Hoffman", "Carlson", "Silva", "Pearson", "Holland", "Douglas", "Fleming"
            ];

        public static string[] Emails = [
            "engmanishk@gmail.com",
            "rowdymanish47@gmail.com",
            "mca23167@glbitm.ac.in"
        ];

        public static string[] FlightNumbers = [
            "AA101", "BA202", "DL303", "UA404", "SW505",
            "AF606", "KL707", "LH808", "EK909", "QR010",
            "SQ111", "CX212", "QF313", "IB414", "TK515",
            "AZ616", "NH717", "AI818", "AC919", "GA020",
            "KE121", "JL222", "VN323", "ET424", "BR525",
            "VS626", "MH727", "PR828", "CZ929", "CA030",
            "MU131", "TG232", "LX333", "OS434", "SK535",
            "AY636", "OA737", "BA838", "FI939", "SU040",
            "LO141", "LY242", "TK343", "AZ444", "EY545",
            "QR646", "EK747", "AF848", "CX949", "SQ050"
        ];

        public static string[] Departures = [
            "LAX", "BOS", "JFK", "ORD", "ATL", "SFO", "SEA", "MIA", "DFW", "DEN",
            "PHX", "LAS", "IAH", "CLT", "DTW", "MSP", "FLL", "EWR", "BWI", "SAN",
            "TPA", "PDX", "STL", "HNL", "MDW", "MCO", "AUS", "DAL", "SLC", "RDU",
            "SMF", "OAK", "HOU", "MKE", "IND", "BNA", "CMH", "SJC", "PIT", "SAT",
            "ONT", "CLE", "SNA", "ANC", "ABQ", "TUS", "BUR", "BOI", "RIC", "OMA"
        ];

        public static string[] Arrivals = [
            "PHL", "ORF", "CHS", "TUL", "BHM", "GRR", "OKC", "PVD", "MSY", "RSW",
            "JAN", "SAV", "LGB", "ISP", "ALB", "RNO", "GSO", "ELP", "BUF", "TYS",
            "ROA", "PWM", "FAT", "COS", "LIT", "CAE", "ICT", "GEG", "DAY", "HSV",
            "PIE", "BTV", "JAX", "MEM", "DSM", "PSP", "EVV", "BOZ", "CHO", "GPT",
            "PBI", "HRL", "MYR", "CRW", "SRQ", "AVL", "TTN", "BZN", "MTJ", "EGE"
        ];

        public static string[] Compensations = [
            "Hotel", "Meal", "HotelAndMeal", "Voucher", "Miles"
        ];

        public static string[] CompStatus = [
            "Offered", "NotOffered", "Pending", "Accepted", "Declined", "Voided"
        ];

        public static string[] EventType = [
            "Controllable", "UnControllable"
        ];

        public static string[] EventReason = [
            "Cancel", "Delay", "Unknown"
        ];

        public static string[] NotificationType = [
            "Email"
        ];

        public static string[] CabinType = [
            "Economy", "Premium", "Business"
        ];

        public static string[] PaxStatus = [
            "Gold", "Silver", "Platinum", "General"
        ];


    }
}
