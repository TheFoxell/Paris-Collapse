using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Player player;
    
    public GameObject InfoUI;
    public List<Item> ListItem;

    public Item itemSelect;

    
    public void ChangeImage(GameObject slot)
    {
        Sprite tmp = null;
        foreach (var elt in ListItem)
        {
            if (slot.GetComponent<Image>().sprite == elt.icon)
            {
                tmp = elt.image;
                itemSelect = elt;
            }
        }

        InfoUI.GetComponent<Image>().sprite = tmp;
    }
    

}
