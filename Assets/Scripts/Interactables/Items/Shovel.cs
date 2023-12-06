using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class Shovel : Interactable
{
    [SerializeField] private soItem item;

    public override void Interact()
    {
        PickUpItem(item, gameObject);
    }
}
