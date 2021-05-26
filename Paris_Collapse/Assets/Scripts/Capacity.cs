using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capacity : MonoBehaviour
{
    public ReadCSV csv;
    public Item item;
    public Player player;

    public void UseCapacity()
    {
        item = csv.itemSelect;
        
        if (item.health != 0)
            player.health += item.health;
        if (item.shield != 0)
            player.shield += item.shield;
        if (item.deg != 0)
            player.damage += (item.deg / 4);
    }

}
