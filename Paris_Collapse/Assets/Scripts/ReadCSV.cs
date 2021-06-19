﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReadCSV : MonoBehaviour
{

    public List<Item> itemListPlayer;
    public List<Item> itemList;
    public List<GameObject> ListSlots = null;
    public Item itemSelect;
    public ItemUI itemUI;


    public string path = "Assets/Data/playerInventory.csv";
    public string InventoryName;

    public AudioClip audioDestroy = null;
    public AudioClip audioUse = null;
    
    public AudioSource audioSource;


    public List<Sprite> sprites;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
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
        foreach (var slot in ListSlots)
        {
            if (slot.GetComponent<Image>().enabled)    //Si not enabled
            {
                slot.GetComponent<Image>().enabled = false;          // set enabled true
                slot.GetComponent<Image>().sprite = null;      // set image item to slot
            }
        }
        
        
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


    public void DeleteItem()
    {
        itemSelect = itemUI.itemSelect;
        string itemName = itemSelect.name;
        
        List<string> ListItems = new List<string>();
        using (StreamReader sr = new StreamReader(path))        //Créer la liste d'item
        {
            string line = sr.ReadLine();
            while (line != null)
            {
                ListItems.Add(line);
                line = sr.ReadLine();
            }
        }
        ListItems.Remove(itemName); //Suppression de l'item dans la liste
        itemListPlayer.Remove(itemSelect);
        using (StreamWriter sw = new StreamWriter(path))        // Actualisation 
        {
            foreach (var item in ListItems)
            {
                sw.WriteLine(item);
            }
        }
        
        if (InventoryName == "Inventaire" )
        {
            audioSource.PlayOneShot(audioDestroy);
            StartCoroutine(WaitAndLoadDestroy());
        }
        if (InventoryName == "InventaireCombat1" || InventoryName == "InventaireCombat2" ||InventoryName == "InventaireCombat3" ||InventoryName == "InventaireCombatBoss")
        {
            audioSource.PlayOneShot(audioUse);
            StartCoroutine(WaitAndLoadUse());
        }
        
        
        
    }

    private IEnumerator WaitAndLoadDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(InventoryName);
    }
    private IEnumerator WaitAndLoadUse()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(InventoryName);
    }
    
}
