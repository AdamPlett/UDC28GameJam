using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject framePrefab;
    [SerializeField] private List<GameObject> itemFrames;

    [SerializeField] private int activeFrame = 0;

    void Update()
    {
        Vector2 scrollDelta = Mouse.current.scroll.ReadValue();

        if(scrollDelta.y > 0)
        {
            ShiftActiveFrame(-1);
        }
        else if(scrollDelta.y < 0)
        {
            ShiftActiveFrame(1);
        }
    }

    public void AddItemFrame(soItem item)
    {
        GameObject newFrame = Instantiate(framePrefab, transform);

        newFrame.GetComponent<ItemFrame>().SetIcon(item.itemSprite);

        itemFrames.Add(newFrame);
    }

    private void ShiftActiveFrame(int increment)
    {
        HighlightFrame(itemFrames[activeFrame], false);

        activeFrame += increment;

        if (activeFrame < 0)
        {
            activeFrame = itemFrames.Count - 1;
        }
        else if(activeFrame >= itemFrames.Count)
        {
            activeFrame = 0;
        }

        HighlightFrame(itemFrames[activeFrame], true);
    }

    private void HighlightFrame(GameObject frame, bool highlight)
    {
        frame.GetComponent<Image>().color = highlight ? Color.cyan : Color.white;
    }
}
