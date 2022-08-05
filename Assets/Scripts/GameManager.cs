using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public static class GameManager
{
    public static UnityEvent<List<IScore>> Score = new UnityEvent<List<IScore>>();
    public static List<IScore> score = new List<IScore>();
    public static void UpdateScore()
    {
        Score.Invoke(score);
    }
}
