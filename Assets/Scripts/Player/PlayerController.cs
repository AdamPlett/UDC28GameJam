using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public Vector3 playerVelocity;
    public float moveSpeed;
    public float sprintSpeed;
    public float rotationDampFactor;

    [Header("Player Interaction")]
    public float interactRange;
    public LayerMask interactLayer;

    // Raycast Variables
    private Ray ray;
    private RaycastHit[] rayResults;
    private int numHits;

    // References
    private InputReader input;
    private CharacterController controller;

    void Start()
    {
        input = GetComponent<InputReader>();
        controller = GetComponent<CharacterController>();

        input.interactPerformed += Interact;
    }

    void Update()
    {
        if(!gm.ui.gamePaused)
        {
            CalculateMoveDirection();
            FaceMoveDirection();
            MovePlayer();
        }
    }

    public void Interact()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        numHits = Physics.RaycastNonAlloc(ray, rayResults, interactRange, interactLayer);

        if(numHits > 0)
        {
            GameObject hitObj = rayResults[0].collider.gameObject;
            Interactable hitInteraction = hitObj.GetComponent<Interactable>();
            
            if (hitInteraction != null)
            {
                hitInteraction.Interact();
                Debug.Log("Interactable Detected: " + hitObj.name);
            }
        }
    }

    #region Movement Functions

    private void CalculateMoveDirection()
    {
        Vector3 cameraForward = gm.mainCamera.transform.forward;
        Vector3 cameraRight = gm.mainCamera.transform.right;

        Vector3 moveDirection = (cameraForward.normalized * input.moveComposite.y) + (cameraRight.normalized * input.moveComposite.x);

        if (input.isSprinting)
        {
            playerVelocity.x = moveDirection.x * sprintSpeed;
            playerVelocity.y = 0f;
            playerVelocity.z = moveDirection.z * sprintSpeed;
        }
        else
        {
            playerVelocity.x = moveDirection.x * moveSpeed;
            playerVelocity.y = 0f;
            playerVelocity.z = moveDirection.z * moveSpeed;
        }
    }

    private void FaceMoveDirection()
    {
        Vector3 faceDirection = new Vector3(playerVelocity.x, 0, playerVelocity.z);

        if(faceDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(faceDirection), rotationDampFactor * Time.deltaTime);
        }
    }

    private void MovePlayer()
    {
        //controller.Move(new Vector3(playerVelocity.x, 0, playerVelocity.z) * Time.deltaTime);

        controller.SimpleMove(playerVelocity);
    }

    #endregion
}
