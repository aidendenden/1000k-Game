using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class ScoreEntry
{
    public string playerName;
    public int score;

    public ScoreEntry(string name, int score)
    {
        this.playerName = name;
        this.score = score;
    }
}

public class LeaderboardManager : MonoBehaviour
{
    public List<ScoreEntry> leaderboard = new List<ScoreEntry>();
    public int maxEntries = 10; // Maximum number of entries in the leaderboard
    private string leaderboardFile = "leaderboard.json";

    private void Start()
    {
        LoadLeaderboard();
    }

    public void AddScore(string playerName, int score)
    {
        ScoreEntry newEntry = new ScoreEntry(playerName, score);
        leaderboard.Add(newEntry);
        leaderboard.Sort((x, y) => y.score.CompareTo(x.score)); // Sort the leaderboard in descending order

        // If we have more than the max entries, remove the last one
        if (leaderboard.Count > maxEntries)
        {
            leaderboard.RemoveAt(leaderboard.Count - 1);
        }

        SaveLeaderboard();
    }

    public void SaveLeaderboard()
    {
        string json = JsonUtility.ToJson(new Serialization<ScoreEntry>(leaderboard), true);
        string filePath = Path.Combine(Application.persistentDataPath, leaderboardFile);
        File.WriteAllText(filePath, json);
    }

    public void LoadLeaderboard()
    {
        string filePath = Path.Combine(Application.persistentDataPath, leaderboardFile);
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            leaderboard = JsonUtility.FromJson<Serialization<ScoreEntry>>(json).ToList();
        }
    }
}

// Helper class to enable JSON serialization of List<T>
[Serializable]
public class Serialization<T>
{
    [SerializeField]
    private List<T> target;
    public List<T> ToList() { return target; }

    public Serialization(List<T> target)
    {
        this.target = target;
    }
}