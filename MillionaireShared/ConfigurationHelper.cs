using System;
using System.IO;
using System.Text.Json;

public static class ConfigurationHelper
{
    private static readonly string ConfigFilePath = GetConfigFilePath();

    private static string GetConfigFilePath()
    {
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        // Navigate up to the solution directory
        string solutionDir = Directory.GetParent(baseDir).Parent.Parent.Parent.Parent.FullName;
        return Path.Combine(solutionDir, "MillionaireShared", "config.json");
    }

    public static string GetFilePath(string key)
    {
        if (!File.Exists(ConfigFilePath))
        {
            CreateDefaultConfigFile();

        }

        string jsonString = File.ReadAllText(ConfigFilePath);
        var config = JsonSerializer.Deserialize<Config>(jsonString);

        string relativePath = key switch
        {
            "QuestionsFilePath" => config.QuestionsFilePath,
            "GameHistoryFilePath" => config.GameHistoryFilePath,
            _ => throw new ArgumentException("Invalid key")
        };

        // Construct the absolute path
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        string solutionDir = Directory.GetParent(baseDir).Parent.Parent.Parent.Parent.FullName;
        return Path.Combine(solutionDir, relativePath);
    }

    private static void CreateDefaultConfigFile()
    {
        var defaultConfig = new Config
        {
            QuestionsFilePath = "MillionaireShared/Questions.txt",
            GameHistoryFilePath = "MillionaireShared/GameHistory.txt"
        };

        string jsonString = JsonSerializer.Serialize(defaultConfig);
        File.WriteAllText(ConfigFilePath, jsonString);

    }
    private class Config
    {
        public string QuestionsFilePath { get; set; }
        public string GameHistoryFilePath { get; set; }
    }
}
