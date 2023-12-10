using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static GameManager;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public Vector3 playerVelocity;
    public float crouchSpeed;
    public float moveSpeed;
    public float sprintSpeed;
    public float rotationDampFactor;

    [Header("Noise Levels")]
    public PlayerNoise playerNoise;

    [Header("Player Interaction")]
    public float interactRange;
    public LayerMask interactLayer;

    [Header("Player Inventory")]
    public Inventory inv;

    // Raycast Variables
    private Ray ray;
    private int numHits;
    private RaycastHit[] rayResults = new RaycastHit[1];

    // References
    private InputReader input;
    private CharacterController controller;

    void Start()
    {
        input = GetComponent<InputReader>();
        controller = GetComponent<CharacterController>();

        input.interactPerformed += Interact;
        input.crouchPerformed += Crouch;
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

        Debug.Log("Interaction attempted; " + numHits);

        if(numHits > 0)
        {
            GameObject hitObj = rayResults[0].collider.gameObject;
            Interactable hitInteraction = hitObj.GetComponent<Interactable>();
            
            if (hitInteraction != null)
            {
                hitInteraction.Interact();
                Debug.Log("Interactable Detected: " + hitObj.name);
            }
            else
            {
                Debug.Log("No Interactable Detected");
            }
        }
    }

    public void Crouch()
    {
        if(input.isCrouched)
        {
            controller.height = 0.5f;
        }
        else
        {
            controller.height = 1.5f;
            controller.center = new Vector3(0, 0, 0);
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
        else if(input.isCrouched)
        {
            playerVelocity.x = moveDirection.x * crouchSpeed;
            playerVelocity.y = 0f;
            playerVelocity.z = moveDirection.z * crouchSpeed;
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
        controller.SimpleMove(playerVelocity);

        if (playerVelocity.x == 0 && playerVelocity.z == 0)
        {
            // Do Nothing
        }
        else
        {
            MakeNoise();
        }
    }

    private void MakeNoise()
    {
        if (input.isSprinting)
        {
            gm.noise.CreateNoise(playerNoise.runLevel, transform.position);
        }
        else if (input.isCrouched)
        {
            gm.noise.CreateNoise(playerNoise.crouchLevel, transform.position);
        }
        else
        {
            gm.noise.CreateNoise(playerNoise.walkLevel, transform.position);
        }
    }

    #endregion
}
