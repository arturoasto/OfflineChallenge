using ConsoleTables;
using CsvHelper;
using OfflineChallenge;
using System.Globalization;

if (args.Length > 1) return;

var regionName = string.Empty;
if (args.Length == 1)
{
    var argument = args[0].Split("=");
    if (argument.Length != 2 || argument[0] != "region")
        throw new ArgumentException("invalid argument");

    regionName = argument[1].Trim().ToLower();
}

var covidInfo = new CovidData();
await covidInfo.GetData();
covidInfo.ParseHtml();

if (covidInfo.Rows.Count == 0)
{
    Console.WriteLine("could not retrieve data now.");
    return;
}

if (!string.IsNullOrWhiteSpace(regionName))
{
    covidInfo.Rows = covidInfo.Rows.Where(x => x.Region.ToLower() == regionName).ToList();
}

using (var db = new CountryCovidInfoDbContext())
{
    var service = new CountryCovidInfoService(db);

    var currentRows = await service.GetCountryCovidInfoAsync();
    if (currentRows.Count > 0)
        await service.DeleteAll(currentRows);

    foreach (var item in covidInfo.Rows)
    {
        await service.Add(item);
    }
}

Console.WriteLine("Finished");

if (!string.IsNullOrWhiteSpace(regionName))
{
    ConsoleTable.From<CountryCovidInfo>(covidInfo.Rows)
                .Configure(o => o.NumberAlignment = Alignment.Right)
                .Write(Format.Default);

    var today = DateTime.Today.ToString("yy_MM_dd");

    using (var writer = new StreamWriter($".\\export_{regionName.Replace(" ", "_")}_{today}.csv"))
    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
    {
        csv.WriteRecords(covidInfo.Rows);
    }
}

Console.ReadKey();
