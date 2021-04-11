using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    
    public int deg = 0;
    public int pen = 0;
    public int pre = 0;
    public int cri = 0;
    public int health = 0;
    public int price = 0;
}
