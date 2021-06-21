using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Debugger : MonoBehaviour
{
    public Player player;
    public GameObject debug;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            debug.SetActive(true);
        }
    }

    public void GiveMoney()
    {
        player.coin += 5000;
    }
    
    public void GiveLevel()
    {
        player.level += 100;
    }
    
    public void GiveLife()
    {
        player.health = player.maxHealth;
        player.shield = player.maxShield;
    }
    
}
