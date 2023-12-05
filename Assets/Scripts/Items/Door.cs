using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private bool doorOpen;
    [SerializeField] private bool doorLocked;

    public override void Interact()
    {

    }

    private void OpenDoor()
    {
        doorOpen = true;
    }

    private void CloseDoor()
    {
        doorOpen = false;
    }
}
