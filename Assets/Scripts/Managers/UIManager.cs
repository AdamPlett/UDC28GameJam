using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public bool gamePaused;

    public HUD hud;

    void Start()
    {
        DisableCursor();
    }

    public void ActivateUI(GameObject menu)
    {
        menu.SetActive(true);
        EnableCursor();
    }

    public void DeactivateUI(GameObject menu)
    {
        menu.SetActive(false);
        DisableCursor();
    }

    public void PauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused ? 0 : 1f;

        if(gamePaused)
        {
            EnableCursor();
        }
        else
        {

        }
    }

    #region Cursor Functions

    public void EnableCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DisableCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    #endregion
}
