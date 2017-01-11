using UnityEngine;
using System.Collections;

 [System.Serializable]
public class Items {
    public string itemName;
    public int itemID;
    public string itemDesc;
    public Texture2D itemIcon;
    public int itemPower;
    public int itemSpeed;
    public ItemType itemtype;
    
    public enum ItemType {
        Classe1,
        Classe2,
        Classe3,
        Classe4,
    }

    public Items(string name, int id, string desc, int power, int speed, ItemType type) {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemPower = power;
        itemSpeed = speed;
        itemtype = type; 
        itemIcon = Resources.Load<Texture2D>("Item Icons/" + name);
    }

    public Items() {
        itemID = -1;
    }
}
