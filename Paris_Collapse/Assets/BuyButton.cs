using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public ItemUI itemUI;
    public Player player;
    public Item itemToBuy;
    public string path = "Assets/Data/playerInventory.csv";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        itemToBuy = itemUI.itemSelect;
    }
    
    public void BuyItem()
    {
        string name = itemToBuy.name;

        int tmpMoney = player.coin - itemToBuy.price;

        if (tmpMoney >= 0)
        {
            player.coin -= itemToBuy.price;
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(name);
            }
        }
    }
}
