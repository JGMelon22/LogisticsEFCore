using LogisticSampleSystem.Services;

Console.Clear();

Console.WriteLine("=== Mock Logistic System ===");

for (int i = 0; i < 50; i++)
{
    LogisticsService.PostMockInfo();
}
// LogisticsService.PostMockInfo(); // Post Data
// LogisticsService.GetDataById(29);
// LogisticsService.UpdateMethod(29);
// LogisticsService.DeleteMethod(29);
LogisticsService.GetData();