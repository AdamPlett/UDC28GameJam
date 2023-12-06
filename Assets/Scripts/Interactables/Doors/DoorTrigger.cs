using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door connectedDoor;
    public bool swingRight;

    private void OnTriggerEnter(Collider hit)
    {
        connectedDoor.SetSwing(swingRight);

        Debug.Log("Switching door orientation to " + swingRight);
    }
}
