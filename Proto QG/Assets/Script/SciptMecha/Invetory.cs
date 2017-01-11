using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Invetory : MonoBehaviour {
    public int slotX, slotY;
    public GUISkin skin;
    public List<Items> inventory = new List<Items>();
    public List<Items> slots = new List<Items>();
    public int[] test = new int[20];
    public bool showInventory;
    private ItemDataBase database;
    private bool showTooltip;
    private string tooltip;

    public int positionXfermer;
    public int positionYfermer;

    private bool draggingItem;
    private Items draggedItem;
    private int prevIndex;

    public int size;
    
	void Start () {
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDataBase>();
        for (int i = 0; i < (slotX * slotY); i++) {
            slots.Add(new Items());
            inventory.Add(new Items());
        }        
        inventory[0] = database.items[0];
        inventory[1] = database.items[1];

        AddItem(0);
        AddItem(1);
        AddItem(2);
        RemoveItem(1);

        print(InventoryContains(1));
        print(InventoryContains(2));
        print(InventoryContains(3));
        /*print(inventory.Count); 
        inventory.Add(database.items[0]);
        print(inventory[0].itemName);*/
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.I)) {
            showInventory = !showInventory;
        }
        if (Input.GetKeyDown(KeyCode.I)) {
            LoadInventory();
        }
    }

    void OnGUI() {
        if (GUI.Button(new Rect(200, 450, 100, 40), "Save")) {
            SaveInventory();
        }
        if (GUI.Button(new Rect(40, 450, 100, 40 ), "Load")) {
            LoadInventory();
        }
        tooltip = "";
        GUI.skin = skin;
        if (showInventory) {
            DrawInvetory();
        }

        if (showTooltip) {
            GUI.Box(new Rect(Event.current.mousePosition.x + 15f, Event.current.mousePosition.y, 200, 200), tooltip, skin.GetStyle("Tooltip"));
        }
        if (draggingItem) {
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), draggedItem.itemIcon);
        }

    }
    void DrawInvetory() {
        if (GUI.Button(new Rect(positionXfermer, positionYfermer, 100, 100), "Fermer")) {
            showInventory = false;
            SaveInventory();
        }
        Event e = Event.current;
        int i = 0;
        for (int y = 0; y < slotY; y++)  {
            for (int x = 0; x < slotX; x++) {
                Rect slotRect = new Rect(x * 110, y * 110, size, size);
                GUI.Box(slotRect, "", skin.GetStyle("Slot"));
                slots[i] = inventory[i];
                Items item = slots[i];
                if (slots[i].itemName != null) {
                    GUI.DrawTexture(slotRect, slots[i].itemIcon);
                    if (slotRect.Contains(e.mousePosition)) {
                        CreateTooltip(slots[i]);
                        showTooltip = true;
                        if (e.button == 0 && e.type == EventType.mouseDrag && !draggingItem) {
                            draggingItem = true;
                            prevIndex = i;
                            draggedItem = slots[i];
                            inventory[i] = new Items();
                        }
                        if (e.type == EventType.mouseUp && draggingItem) {
                            inventory[prevIndex] = inventory[i];
                            inventory[i] = draggedItem;
                            draggingItem = false;
                            draggedItem = null;
                        }
                        if (e.isMouse && e.type == EventType.mouseDown && e.button == 1) {
                            print("clic" + i);
                            if (item.itemtype == Items.ItemType.Classe1) {
                                print("c'est la classe 1");
                                UseConsumable(item, i, true);   //Utilise l'objet et le supprime de l'inventaire

                            }
                        }
                        if (Input.GetKey(KeyCode.D)) {  //
                            inventory[i] = new Items(); // supprime l'iteme survoler
                            print("delete ");           //
                        }
                    }
                } else {
                    if (slotRect.Contains(e.mousePosition)) {
                        if (e.type == EventType.mouseUp && draggingItem) {
                            inventory[i] = draggedItem;
                            draggingItem = false;
                            draggedItem = null;
                        }
                    }
                }
                if (tooltip == "") {
                    showTooltip = false;
                }
                i++;                
            }
        }
    }

    string CreateTooltip(Items item) {
        tooltip = "<color=#ffffff>" +  item.itemName + "\n \n" + item.itemDesc + "</color>";
        return tooltip;
    }

    void AddItem (int id) {
        for (int i = 0; i < inventory.Count; i++) {
            if(inventory[i].itemName == null) {
                for (int j = 0; j < database.items.Count; j++) {
                    if (database.items[j].itemID == id) {
                        inventory[i] = database.items[j];
                    }
                }
                //inventory[i] = database.items[id];
                break;
            }
        }
    }

    void RemoveItem(int id) {
        for (int i = 0; i < inventory.Count; i++) {
            if (inventory[i].itemID == id) {
                inventory[i] = new Items();
                break;
            }
        }
    }

    bool InventoryContains(int id) {
        foreach (Items item in inventory) {
            if (item.itemID == id) return true;
        }
        return false;
    }
    private void UseConsumable(Items item, int slot, bool deletItem) {      //
        switch (item.itemID) {                                              //
            case 2: {                                                       //
                    print("destruction de l'objet : " + item.itemName);     //
                    break;                                                  //
                }                                                           // Utilise l'objet et le supprime de l'inventaire
        }                                                                   //
        if (deletItem) {                                                    //
            inventory[slot] = new Items();                                  //
        }                                                                   //
    }                                                                       //

    public void SaveInventory() {
        for (int i = 0; i < inventory.Count; i++) {
            PlayerPrefs.SetInt("Inventory" + i, inventory[i].itemID);
        }        
    }
    public void LoadInventory() { 
        for (int i = 0; i < inventory.Count; i++) {
            test[i] = PlayerPrefs.GetInt("Inventory" + i);
        }
        for (int i = 0; i < 20; i++) {
            inventory[i] = test[i] != -1 ? database.items[test[i]] : new Items();
        }
    }
}