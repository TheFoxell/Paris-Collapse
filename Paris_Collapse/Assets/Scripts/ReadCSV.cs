using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{

    public List<Item> itemListPlayer;
    public List<Item> itemList;
    
    public string path = "Assets/Data/playerInventory.csv";
    public Transform ItemSlots;
    
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
                Debug.Log("Add "+ item.name );
            }
        }
        
    }

    void AddItems()
    {
        InventorySlot[] slots;

        slots = ItemSlots.GetComponentsInChildren<InventorySlot>();
        
        foreach (var elt in itemListPlayer)
        {
            Debug.Log("Count " + itemListPlayer.Count);
            
            for (int i = 0; i < slots.Length ; i++)
            {
                if (i < itemList.Count)
                {
                    slots[i].AddItem(elt);  
                    Debug.Log("Add UI " + elt);
                }
            }
        }
    }
    
}
