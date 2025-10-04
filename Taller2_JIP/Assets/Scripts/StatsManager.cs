using UnityEngine;
using System.IO;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;

    public PlayerStats stats = new PlayerStats();
    private string savePath;

    private void Awake()
    {
        // Patrón Singleton (una sola instancia)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        savePath = Path.Combine(Application.persistentDataPath, "player_stats.json");
        LoadStats();
    }

    private void Update()
    {
        // Incrementar tiempo jugado
        stats.playTime += Time.deltaTime;
    }

    public void AddCoin(int amount = 1)
    {
        stats.coins += amount;
    }

    public void AddKill(int amount = 1)
    {
        stats.kills += amount;
    }

    public void AddDeath(int amount = 1)
    {
        stats.deaths += amount;
    }

    public void SaveStats()
    {
        string json = JsonUtility.ToJson(stats, true);
        File.WriteAllText(savePath, json);
        Debug.Log($"Stats saved to {savePath}");
    }

    public void LoadStats()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            stats = JsonUtility.FromJson<PlayerStats>(json);
        }
        else
        {
            stats = new PlayerStats(); // reinicia si no hay archivo
        }
    }

    public void ResetStats()
    {
        stats = new PlayerStats();
        SaveStats();
    }
}
