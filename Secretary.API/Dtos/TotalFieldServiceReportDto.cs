namespace Secretary.API.Dtos
{
    public class TotalFieldServiceReportDto
    {
        public string description { get; set; }
        public int studies { get; set; }
        public int hours { get; set; }
        public int returns { get; set; }
        public int colocations { get; set; }
        public int videos { get; set; }
        public int betelHours { get; set; }
        public int creditHours { get; set; }
    }
}