using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intouchable : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {


            var hits = Physics.SphereCastAll(transform.position, 0.2f, transform.forward, 1f);
            foreach (var hit in hits)
            {
                if (hit.collider.TryGetComponent<IInteractible>(out var interactible))
                {
                    interactible.Interact(GetComponentInParent<Inventory>());
                    break;
                }
            }
        }
    }
}
