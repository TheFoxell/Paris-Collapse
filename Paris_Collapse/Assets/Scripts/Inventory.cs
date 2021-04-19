using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //test
    public string path = "Assets/Data/playerInventory.csv";
    public static Inventory instance;

    #region Singleton
    void Awake()
    {

        if(instance != null)
        {
            Debug.LogWarning("Plus qu'un inventaire de trouvé");
        }

        instance = this;
    }

    #endregion


    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if(!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough slots.");
                return false;
            }

            items.Add(item);
            AddCSV(item);

            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    void AddCSV(Item item)
    {
        string name = item.name;
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(name);
        }	
        
    }
}
