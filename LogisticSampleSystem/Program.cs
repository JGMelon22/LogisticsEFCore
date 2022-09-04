using LogisticSampleSystem.Services;

Console.Clear();

Console.WriteLine("=== Mock Logistic System ===");

for (int i = 0; i < 50; i++)
{
    LogisticsService.PostMockInfo();
}
// LogisticsService.PostMockInfo(); // Post Data

LogisticsService.GetDataById(40);
LogisticsService.UpdateMethod(39);
// LogisticsService.UpdateMethod(8);
// LogisticsService.DeleteMethod(40);
// LogisticsService.GetData();