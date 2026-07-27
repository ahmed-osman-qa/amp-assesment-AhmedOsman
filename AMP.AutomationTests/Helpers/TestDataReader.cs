using System.Text.Json;

namespace AMP.AutomationTests.Helpers
{
    public static class TestDataReader
    {
        private static readonly Dictionary<string, Dictionary<string, Dictionary<string, string>>> _testData
            = LoadTestData();

        private static Dictionary<string, Dictionary<string, Dictionary<string, string>>> LoadTestData()
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, "TestData", "testData.json");
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(
                    $"Test data file was not found: {filePath}");
            }

            var json = File.ReadAllText(filePath);

            var data = JsonSerializer.Deserialize<
                Dictionary<string, Dictionary<string, Dictionary<string, string>>>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return data ?? throw new InvalidOperationException(
                "Test data could not be loaded.");
        }

        public static Dictionary<string, string> GetData(string section, string dataSet)
        {
            if (!_testData.TryGetValue(section, out var sectionData))
            {
                throw new KeyNotFoundException(
                    $"Test data section '{section}' was not found.");
            }

            if (!sectionData.TryGetValue(dataSet, out var data))
            {
                throw new KeyNotFoundException(
                    $"Test data set '{dataSet}' was not found in section '{section}'.");
            }

            return data;
        }
    }
}