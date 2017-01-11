using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDataBase : MonoBehaviour {
    public List<Items> items = new List<Items>();

    void Start() {
        items.Add(new Items("Cube", 0, "c'est le cube 1", 0, 0, Items.ItemType.Classe1));
        items.Add(new Items("Cube 2",1,"c'est le cube 2", 0, 0, Items.ItemType.Classe2));
        items.Add(new Items("Cube 3",2,"c'est le cube 3", 0, 0, Items.ItemType.Classe3));
        items.Add(new Items("Deplacement", 3, "c'est l'objet test", 0, 0, Items.ItemType.Classe4));
    }
}