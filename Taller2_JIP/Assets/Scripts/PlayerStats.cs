using System;

[Serializable]
public class PlayerStats
{
    public int coins;
    public int kills;
    public int deaths;
    public float playTime; // tiempo total jugado en segundos

    public PlayerStats()
    {
        coins = 0;
        kills = 0;
        deaths = 0;
        playTime = 0;
    }
}
