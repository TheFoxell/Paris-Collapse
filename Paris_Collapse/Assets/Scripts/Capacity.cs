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
        if (item.pen != 0)
            player.pen += (item.pen / 4);
        if (item.pre != 0)
            player.pre += (item.pre / 4);
        if (item.cri != 0)
            player.cri += (item.cri / 4);
    }

}
