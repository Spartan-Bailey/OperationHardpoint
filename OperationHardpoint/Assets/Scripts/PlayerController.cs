using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject Player;
    private CharacterActions CharacterActions;
    private Rigidbody2D Rigidbody;
    [SerializeField] CameraController CameraController;
    [SerializeField] private InputActionReference movement, jump, switching;
    [SerializeField] private PlayerInput Controls;
    private int selectedPlayer = 0;
    private int maxVal;
    private float drX;
    private float movementSpeed = 0f;
    private float drY;

    private bool releaseQE = false;

    void Start()
    {
        maxVal = transform.childCount - 1;
        GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (releaseQE && switching.action.ReadValue<float>() > 0) // if the player is switching
        {
            selectedPlayer++;
            if (selectedPlayer > maxVal)
            {
                selectedPlayer = 0;
            }
            GetPlayer();
            releaseQE = false;
        }
        else if (releaseQE && switching.action.ReadValue<float>() < 0) // switch controlled character (right)
        {
            selectedPlayer--;
            if (selectedPlayer < 0)
            {
                selectedPlayer = maxVal;
            }
            GetPlayer();
            releaseQE = false;
        }

        if(switching.action.ReadValue<float>() == 0)
        {
            releaseQE = true;
        }
        // Pause Screen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }

        // Get horizontal movement input
        drX = movement.action.ReadValue<float>();
        // Check if the player wants to run
        if (false)
        {
            // set to run speeds
            drX = drX * 2.5f;
        }

        // set the player movement
        CharacterActions.SetDrX(drX);
        CharacterActions.Walk();
        //if crouch is pressed
        if (false)
        {
            CharacterActions.ToggleCrouch();
        }
        //if jump is pressed
        if (jump.action.IsPressed())
        {
            CharacterActions.Jump();
        }
    }
    public void GetPlayer()
    {
        Debug.Log(transform.GetChild(selectedPlayer).gameObject.ToString());
        Player = transform.GetChild(selectedPlayer).gameObject;

        CharacterActions = Player.GetComponent<CharacterActions>();
        movementSpeed = CharacterActions.GetMovementSpeed();
        Rigidbody = Player.GetComponent<Rigidbody2D>();
        CameraController.UpdatePlayer(Player.transform);
    }




}
