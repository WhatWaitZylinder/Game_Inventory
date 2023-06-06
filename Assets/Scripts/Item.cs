using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item 
{
    public string Name;
    public int ID;
    public Sprite Icon;

    public abstract void OnAdded(Inventory inventory);
    public abstract void OnRemoved(Inventory inventory);

    public Item(string name, int id, string spritepath)
    {
        Name = name;
        ID = id;
        Icon = Resources.Load<Sprite>(spritepath);

    }

}
