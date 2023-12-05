using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class Inventory : MonoBehaviour
{
    [SerializeField] private soItem equippedItem;
    [SerializeField] private List<soItem> heldItems;

    [SerializeField] private int maxItems;
    [SerializeField] private bool inventoryFull;

    public void AddItem(soItem item)
    {
        if(heldItems.Count < maxItems)
        {
            heldItems.Add(item);
            gm.ui.hud.AddItemFrame(item);
        }
    }

    public void RemoveItem(soItem item)
    {
        heldItems.Remove(item);
    }
}
