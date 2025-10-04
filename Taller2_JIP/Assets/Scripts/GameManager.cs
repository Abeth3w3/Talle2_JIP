using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Coins { get; private set; }
    public int Kills { get; private set; }
    public int Deaths { get; private set; }
    public int Score { get; private set; }

    private float elapsedTime;
    private Dictionary<ItemType, int> itemsCollected = new Dictionary<ItemType, int>();

    public bool HasKey { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    public void AddCoin(int val = 1) { Coins += val; Score += val * 10; }
    public void AddKill(int val = 1) { Kills += val; Score += 50 * val; }
    public void AddDeath(int val = 1) { Deaths += val; Score -= 20 * val; }
    public void AddItem(ItemType type, int val = 1)
    {
        if (!itemsCollected.ContainsKey(type)) itemsCollected[type] = 0;
        itemsCollected[type] += val;
        AddCoin(val);
    }

    public float GetElapsedTime() => elapsedTime;

    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ResetForNewRun()
    {
        Coins = 0; Kills = 0; Deaths = 0; Score = 0; elapsedTime = 0;
        itemsCollected.Clear();
        HasKey = false; 
    }

    public void GetKey()
    {
        HasKey = true;
        Debug.Log("¡Llave conseguida!");
    }
}
