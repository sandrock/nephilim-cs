namespace Nephilim.Utils;

// see https://github.com/DuaelFr/nephilim-almanac-bot/blob/master/config.json

public class Constants
{
    public static readonly List<Almanac> almanac;
    public static readonly Dictionary<DayOfWeek,string> days;

    static Constants()
    {
        days = new Dictionary<DayOfWeek, string>();
        days[DayOfWeek.Sunday] = "Soleil";
        days[DayOfWeek.Monday] = "Lune";
        days[DayOfWeek.Tuesday] = "Feu";
        days[DayOfWeek.Wednesday] = "Eau";
        days[DayOfWeek.Thursday] = "Air";
        days[DayOfWeek.Friday] = "Terre";
        days[DayOfWeek.Saturday] = "Orichalque";
        almanac = new List<Almanac>();
        almanac.Add(new Almanac("Capricorne", "Lune", "Lune", 19, 01, "Lundi"));
        almanac.Add(new Almanac("Verseau", "Saturne", "Orichalque", 18, 02, "Samedi"));
        almanac.Add(new Almanac("Poisson", "Jupiter", "Air", 20, 03, "Jeudi"));
        almanac.Add(new Almanac("Bélier", "Mars", "Feu", 20, 04, "Mardi"));
        almanac.Add(new Almanac("Taureau", "Vénus", "Terre", 20, 05, "Terre"));
        almanac.Add(new Almanac("Gémeaux", "Mercure", "Eau", 21, 06, "Mercredi"));
        almanac.Add(new Almanac("Cancer", "Lune", "Lune", 22, 07, "Lundi"));
        almanac.Add(new Almanac("Lion", "Soleil", "Soleil", 22, 08, "Tous les jours"));
        almanac.Add(new Almanac("Vierge", "Mercure", "Eau", 22, 09, "Mercredi"));
        almanac.Add(new Almanac("Balance", "Vénus", "Terre", 22, 10, "Mardi"));
        almanac.Add(new Almanac("Scorpion", "Mars", "Feu", 21, 11, "Mardi"));
        almanac.Add(new Almanac("Sagittaire", "Jupiter", "Air", 20, 12, "Jeudi"));
    }
}

public class Almanac
{
    public Almanac(string sign, string star, string ka, int day, int month, string dayOfWeek)
    {
        this.Sign = sign;
        this.Star = star;
        this.Ka = ka;
        this.Day = day;
        this.Month = month;
        this.DayOfWeek = dayOfWeek;
    }

    public string Sign { get; }

    public string Star { get; }

    public string Ka { get; }

    public int Day { get; }

    public int Month { get; }

    public string DayOfWeek { get; }
}
