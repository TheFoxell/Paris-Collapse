using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Unit unit;
    
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
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        LoadPlayer();
    }

    // Update is called once per frame
    void Update()
    {


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
