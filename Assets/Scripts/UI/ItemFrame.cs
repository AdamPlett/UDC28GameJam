using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemFrame : MonoBehaviour
{
    [SerializeField] Image itemIcon;

    public void SetIcon(Sprite icon)
    {
        itemIcon.sprite = icon;
    }
}
