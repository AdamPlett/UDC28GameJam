using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "SOs/Items")]
public class soItem : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;

    [Space(10)]
    public bool itemCollected;

    void Awake()
    {
        itemCollected = false;
    }
}
