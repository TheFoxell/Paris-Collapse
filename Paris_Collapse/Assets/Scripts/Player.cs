using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Unit unit;

    public int maxHealth = 100;
    public HealthBar healthBar;
    
    public int level = 1;
    public int health = 75;
    public int coin = 500;

    public bool saving = true;
    
    
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        coin = data.coin;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        LoadPlayer();
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(health);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar != null)
        {
            healthBar.SetHealth(health);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            StopSaving();
        }

        if(saving)
            SavePlayer();
    }


    public void StopSaving()
    {
        saving = !saving;
        SaveSystem.Delete("player");
    }
    
}
