using HtmlAgilityPack;

namespace OfflineChallenge
{
    public class CovidData
    {
        public string? Data { get; set; }
        public List<CountryCovidInfo> Rows { get; set; } = new List<CountryCovidInfo>();

        public async Task GetData()
        {
            string url = "https://www.worldometers.info/coronavirus/";
            var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync(url);
            Data = response;
        }

        public void ParseHtml()
        {
            var html = new HtmlDocument();
            html.LoadHtml(Data);

            var query = html.DocumentNode.SelectNodes("//table[@id='main_table_countries_today']//tbody[1]//tr[not(contains(@class,'total_row_world'))]");

            foreach (var item in query)
            {
                var text = item.InnerText;
                var list = text.Split("\n");

                var row = new CountryCovidInfo()
                {
                    ActiveCases = list[9],
                    Region = list[16],
                    Name = list[2],
                    TotalCases = list[3],
                    TotalTests = list[13]
                };

                Rows.Add(row);
            }

            Console.WriteLine("parsing ...");
        }
    }
}
