using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{

    public List<Item> itemList; 
        
    // Start is called before the first frame update
    void Start()
    {
        ReadTextCSV();
    }
    
    //Lit le fichier .csv et créer une liste d'item
    void ReadTextCSV()
    {
        using (StreamReader sr = new StreamReader("Assets/Data/playerInventory.csv"))
        {
            string line = sr.ReadLine();
            while (line != "")
            {
                line = sr.ReadLine();
                Item tmpItem = CreateItem(ParseLine(line));
                itemList.Add(tmpItem);
            }
        }
    }

    string[] ParseLine(string line)
    {
        string[] parseline = line.Split(',');
        return parseline;
    }

    Item CreateItem(string[] parseLine)
    {
        Item tmpItem = new Item();
        for (int i = 0; i < parseLine.Length; i++)
        {
            //todo
        }
        
        return tmpItem;
    }
    
    
    
    
}
