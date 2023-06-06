using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour, IInteractible
{
    public Item Item { get; private set; }

    private Camera pv_Cam;

    private void Awake()
    {
        pv_Cam = Camera.main;
    }

    public static ItemHolder Create(Item Item, Vector3 position)
    {

        GameObject holderObject = Instantiate(Resources.Load<GameObject>("ItemHolder"));
        ItemHolder holder = holderObject.GetComponent<ItemHolder>();
        holder.Item = Item;
        holder.transform.position = position;
        holder.GetComponent<SpriteRenderer>().sprite = Item.Icon;

        return holder;
    }

    /// <summary>
    /// Rotation Object
    /// </summary>
    /// <param name="original"></param>
    /// <param name="destination"></param>
    /// <param name="reversed"></param>
    /// <returns></returns>
    Quaternion RotateTo(Vector3 original, Vector3 destination, bool reversed)
    {
        if (reversed)
        {
            return Quaternion.LookRotation(original - destination);
        }
        return Quaternion.LookRotation(destination - original);
    }

    void Update()
    {
        transform.rotation = RotateTo(transform.position, pv_Cam.transform.position, false);
    }


    /// <summary>
    /// Interaction Object
    /// </summary>
    /// <param name="object"></param>
    public void Interact(object @object)
    {
        if(@object is Inventory inventory)
        {
            inventory.AddItem(Item);
            Destroy(gameObject);
        }
    }
}
