using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject
{
    public string name { get; set; }
    public int score { get; set; }

    public PlayerObject(string playerName, int playerScore)
    {
        this.name = playerName;
        this.score = playerScore;
    }
}
