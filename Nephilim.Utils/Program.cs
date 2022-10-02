
using Nephilim.Utils;
using System;
using System.Globalization;
using System.Runtime.InteropServices;

var lang = new CultureInfo("fr-FR");
var referenceDate = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc);
referenceDate = DateTime.Now;
int days = 10;

var helpArgs = new string[] { "/?", "-h", "--help", "/help", };
if (args.Length > 0 && args.Any(x => helpArgs.Contains(x, StringComparer.OrdinalIgnoreCase)))
{
    Console.WriteLine();
    Console.WriteLine("Nephilim markdown log generator");
    Console.WriteLine("Will generate a sample document for your session. ");
    Console.WriteLine();
    Console.WriteLine("Specify the game date as argument (YYYY-MM-DD)");
    Console.WriteLine("Specify the number of days to generate");
    Console.WriteLine("");
    return;
}

if (args.Length >= 1)
{
    if (DateTime.TryParse(args[0], CultureInfo.InvariantCulture, DateTimeStyles.None, out referenceDate))
    {
    }
    else
    {
        Console.Error.WriteLine("WTF is that date? ");
        Environment.ExitCode = 1;
        return;
    }
}

if (args.Length >= 2)
{
    if (int.TryParse(args[1], NumberStyles.Integer, CultureInfo.CurrentCulture, out days))
    {
    }
    else
    {
        Console.Error.WriteLine("WTF is that number? ");
        Environment.ExitCode = 1;
        return;
    }
}

if (args.Length >= 3)
{
    Console.Error.WriteLine("Too many arguments. ");
    Environment.ExitCode = 1;
    return;
}

//
// generate commonmark now
Console.WriteLine();
Console.WriteLine("");
Console.WriteLine("Session XXX - " + DateTime.Now.ToString("yyyy-MM-dd", lang) + " - CAMPAGNE");
Console.WriteLine("==========================");
Console.WriteLine("");

var longestKa = Constants.days.Values.Max(x => x.Length) + 1;
for (int i = 0; i < days; i++)
{
    var date = referenceDate.AddDays(i);
    var jourKa = KaFromDay(date.DayOfWeek);
    var item = GetDateInfo(date);
    Console.Write($"## Le {date.ToString("dddd", lang).PadRight(8)} {date.ToString("yyyy-MM-dd", lang)}, ");
    Console.Write($"jour {jourKa}, ");
    Console.Write($"{Spaces(longestKa-jourKa.Length)} mois {item.Ka}");
    if (item.Ka == jourKa)
    {
        Console.Write($", conjonction");
    }
    
    Console.WriteLine();
    Console.WriteLine();
}


string KaFromDay(DayOfWeek day)
{
    switch (day)
    {
        case DayOfWeek.Sunday:
            return "Soleil";
        case DayOfWeek.Monday:
            return "Lune";
        case DayOfWeek.Tuesday:
            return "Feu";
        case DayOfWeek.Wednesday:
            return "Eau";
        case DayOfWeek.Thursday:
            return "Air";
        case DayOfWeek.Friday:
            return "Terre";
        case DayOfWeek.Saturday:
            return "Orichalque";
        default:
            throw new ArgumentOutOfRangeException(nameof(day), day, null);
    }
}

Almanac GetDateInfo(DateTime date)
{
    var found = false;
    int i = 0, n = Constants.almanac.Count;
    Almanac result = null;
    while (!found && i < n)
    {
        var item = Constants.almanac[i];
        var limitDate = new DateTime(date.Year, item.Month, item.Day, 0, 0, 0, DateTimeKind.Utc);
        if (date <= limitDate)
        {
            found = true;
            result = item;
        }
        else
        {
            i++;
        }
    }

    if (!found)
    {
        i = 0;
    }

    return result;
}

string Spaces(int count)
{
    return new string(Enumerable.Repeat(' ', count).ToArray());
}
