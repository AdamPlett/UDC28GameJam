using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public Camera mainCamera;
    public UIManager ui;
    public AudioManager audio;

    public void Awake()
    {
        if(gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
