using System;
using System.IO;
using System.Text.Json;

public static class ConfigurationHelper
{
    private static readonly string ConfigFilePath = GetConfigFilePath();

    private static string GetConfigFilePath()
    {
        // Locate the solution directory and navigate to the MillionaireShared folder
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        string solutionDir = Directory.GetParent(baseDir).Parent.Parent.Parent.Parent.FullName;
        return Path.Combine(solutionDir, "MillionaireShared", "config.json");
    }

    public static string GetFilePath(string key)
    {
        if (!File.Exists(ConfigFilePath))
        {
            throw new FileNotFoundException("Configuration file not found.");
        }

        string jsonString = File.ReadAllText(ConfigFilePath);
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
