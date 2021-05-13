using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int health;
    public float[] position;
    public int coin;
    public int exp;
    public int expMax;
    public int shield;


    public PlayerData(Player player)
    {
        level = player.level;
        health = player.health;
        coin = player.coin;
        exp = player.exp;
        expMax = player.expMax;
        shield = player.shield;
        
        

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
