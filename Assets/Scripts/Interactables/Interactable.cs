using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;
using static UnityEditor.Progress;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact();

    public virtual void PickUpItem(soItem item, GameObject obj)
    {
        gm.player.inv.AddItem(item);

        item.itemCollected = true;
        Destroy(obj, 0.1f);
    }
}
