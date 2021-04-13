using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public GameObject InfoUI;
    public List<Item> ListItem;
    
    public void ChangeImage(GameObject slot)
    {
        Sprite tmp = null;
        foreach (var elt in ListItem)
        {
            if (slot.GetComponent<Image>().sprite == elt.icon)
            {
                tmp = elt.image;
            }
        }

        InfoUI.GetComponent<Image>().sprite = tmp;
    }
}
