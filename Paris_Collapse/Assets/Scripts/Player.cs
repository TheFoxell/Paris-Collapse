﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Unit unit;

    public int maxHealth = 100;
    public HealthBar healthBar;
    public ShieldBar shieldBar;
    public ExpBar expBar;
    
    public int level = 1;
    public int expMax = 100;
    public int exp = 90;

    public int maxShield = 100;
    public int shield = 25;
    
    public int health = 100;
    public int coin = 500;

    public bool saving = true;

    private float timestamp = 0.0f;
    public int regeneration = 5;
    
    
    
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;
        exp = data.exp;
        expMax = data.expMax;
        shield = data.shield;

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
        
        if (shieldBar != null)
        {
            shieldBar.SetMaxShield(maxShield);
            shieldBar.SetShield(shield);
        }
        
        if (expBar != null)
        {
            expBar.SetMaxExp(expMax);
            expBar.SetExp(exp);
        }
        
        InvokeRepeating("Regenerate", 0.0f, 10.0f / regeneration);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar != null)
            healthBar.SetHealth(health);
        
        
        if(shieldBar != null)
            shieldBar.SetShield(shield);
        
        if(expBar != null)
            expBar.SetExp(exp);

        if (Input.GetKeyDown(KeyCode.P))
            StopSaving();

        if(saving)
            SavePlayer();
        
        UpdateLevel();
        
    }


    public void UpdateLevel()
    {
        if (exp >= expMax)
        {
            exp -= expMax;
            expMax += 50;
            level += 1;
        }
    }
    public void StopSaving()
    {
        saving = !saving;
        SaveSystem.Delete("player");
    }

    void Regenerate()
    {
        if (health < maxHealth && Time.time > (timestamp + 10.0f))
            health += 1;
    }
    
}
// for commit