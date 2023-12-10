using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    [Header("Managers")]
    public UIManager ui;
    public AudioManager audio;
    public NoiseManager noise;

    [Header("Player Variables")]
    public PlayerController player;
    public GameObject playerInstance, playerPrefab;

    [Header("Enemy Variables")]
    public List<EnemyStateMachine> enemies;

    [Header("Camera Variables")]
    public Camera mainCamera;
    public CinemachineVirtualCamera vCam;
    public CinemachineTransposer transposer;


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

        InitPlayer();
    }

    private void InitPlayer()
    {
        if (player == null)
        {
            playerInstance = Instantiate(playerPrefab, this.transform);
            player = playerInstance.GetComponent<PlayerController>();
        }

        InitCamera();
    }

    private void InitCamera()
    {
        vCam.transform.position = playerInstance.transform.position;
        transposer = vCam.GetCinemachineComponent<CinemachineTransposer>();
        
        if(vCam.Follow == null)
        {
            vCam.Follow = playerInstance.transform;
        }
    }
}