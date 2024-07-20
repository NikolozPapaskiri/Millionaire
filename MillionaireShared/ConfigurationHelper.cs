using System;
using System.IO;
using System.Text.Json;

public static class ConfigurationHelper
{
    public static string GetFilePath(string key)
    {
        string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
        if (!File.Exists(configPath))
        {
            throw new FileNotFoundException("Configuration file not found.");
        }

        string jsonString = File.ReadAllText(configPath);
        var config = JsonSerializer.Deserialize<Config>(jsonString);
        return key switch
        {
            "QuestionsFilePath" => config.QuestionsFilePath,
            "GameHistoryFilePath" => config.GameHistoryFilePath,
            _ => throw new ArgumentException("Invalid key")
        };
    }

    private class Config
    {
        public string QuestionsFilePath { get; set; }
        public string GameHistoryFilePath { get; set; }
    }
}
