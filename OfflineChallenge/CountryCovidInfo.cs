namespace OfflineChallenge
{
    public  class CountryCovidInfo
    {
        public int CountryCovidInfoId { get; set; }
        public string Region { get; set; } = "";
        public string Name { get; set; } = "";
        public string TotalCases { get; set; } = "";
        public string TotalTests { get; set; } = "";
        public string ActiveCases { get; set; } = "";
    }
}
