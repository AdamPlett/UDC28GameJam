using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class Lure : Interactable
{
    public float noiseLevel;

    public override void Interact()
    {
        gm.noise.CreateNoise(noiseLevel, transform.position);
    }
}
