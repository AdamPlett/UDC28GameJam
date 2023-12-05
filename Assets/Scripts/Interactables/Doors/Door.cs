using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private bool canInteract = true;
    [Space(10)]
    [SerializeField] private bool doorOpen;
    [SerializeField] private bool doorLocked;
    [Space(10)]
    [SerializeField] private bool swingRight;
    [SerializeField] private float swingDuration;

    public override void Interact()
    {
        if(canInteract)
        {
            if (doorOpen)
            {
                CloseDoor();
            }
            else
            {
                OpenDoor();
            }
        }
    }

    private void OpenDoor()
    {
        Quaternion rotation = swingRight ? Quaternion.Euler(0, 90, 0) : Quaternion.Euler(0, -90, 0);

        StartCoroutine(SwingDoor(rotation));

        doorOpen = true;
    }

    private void CloseDoor()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 0);

        StartCoroutine(SwingDoor(rotation));

        doorOpen = false;      
    }

    IEnumerator SwingDoor(Quaternion endRot)
    {
        canInteract = false;
        Quaternion startRot = transform.rotation;

        for (float t = 0; t < swingDuration; t += Time.deltaTime)
        {
            transform.rotation = Quaternion.Slerp(startRot, endRot, t / swingDuration);
            yield return null;
        }

        canInteract = true;
    }

    public void SetSwing(bool swing)
    {
        swingRight = swing;
    }
}
