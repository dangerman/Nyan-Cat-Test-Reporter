namespace NyanCatReporterDataCollector
{
    public class TestStats
    {
        public int Passed { get; set; }
        public int Failed { get; set; }
        public int Other { get; set; }
        public int Total { get; set; }

        public TestStats()
        {
            Passed = 0;
            Failed = 0;
            Other = 0;
            Total = 0;
        }
    }
}