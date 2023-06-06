using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<Item> Items { get; private set; } = new List<Item>();

    public void AddItem(Item item)
    {
        Items.Add(item);
        item.OnAdded(this);

    }
    public void RemoveItem(Item item)
    {
        if (Items.Remove(item))
           item.OnRemoved(this);

    }
}
