using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ReadCSV : MonoBehaviour
{

    public List<Item> itemListPlayer;
    public List<Item> itemList;
    public List<GameObject> ListSlots = null;


    public string path = "Assets/Data/playerInventory.csv";
    
    
    public List<Sprite> sprites;
    
    // Start is called before the first frame update
    void Start()
    {
        ReadTextCSV();
        AddItems();
    }
    
    //Lit le fichier .csv et créer une liste d'item
    void ReadTextCSV()
    {
        using (StreamReader sr = new StreamReader(path))
        {
            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                Debug.Log("Add "+ line );
                CreateItem(line);
                
            }
        }
    }

    // Pour chaque ca va créer un Item avec les caractéritiques
    void CreateItem(string line)
    {
        
        foreach (var item in itemList)
        {
            if (item.name == line)
            {
                itemListPlayer.Add(item);
            }
        }
        
    }

    void AddItems()
    {
        foreach (var item in itemListPlayer)
        {
            Sprite slotImage = item.icon;
            bool find = false;
            
            foreach (var slot in ListSlots)  //Pour chaque Item dans le SlotHolder
            {
                if (!slot.GetComponent<Image>().enabled && !find)    //Si not enabled
                {
                    Debug.Log("Image null");
                    slot.GetComponent<Image>().enabled = true;          // set enabled true
                    slot.GetComponent<Image>().sprite = slotImage;      // set image item to slot
                    find = true;
                }
            }
        }

    }

    public List<Item> GetitemListPlayer()
    {
        return itemListPlayer;; 
    }
    
}
