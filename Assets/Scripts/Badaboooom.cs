using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badaboooom : Item
{
    public Badaboooom() : base(nameof(Badaboooom),404, "Image/Badaboooom")
    {

    }

    public override void OnAdded(Inventory inventory)
    {
       if(inventory.TryGetComponent(out Rigidbody RB))
        {
            RB.AddForce(Vector3.up * 10000, ForceMode.Impulse);
        }
    }

    public override void OnRemoved(Inventory inventory)
    {
        if (inventory.TryGetComponent(out Rigidbody RB))
        {
            RB.velocity = Vector3.zero;
            if(RB.SweepTest(-RB.transform.up, out RaycastHit hit))
            {
                RB.MovePosition(hit.point);
            }
        }
    }
}
