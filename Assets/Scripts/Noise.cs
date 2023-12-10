using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{
    bool latestNoise;

    public void DestroyNoise()
    {
        if(!latestNoise)
        {
            Destroy(gameObject);
        }
    }
}
