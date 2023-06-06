using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerInventory : Inventory
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            ItemHolder.Create(new Badaboooom(), transform.position);
        if (Input.GetKeyDown(KeyCode.O))
        {

            var item = Items.FirstOrDefault();
            if(item != null)
            {
                RemoveItem(item);
                ItemHolder.Create(item, transform.position);
            }

        }
    }
}
