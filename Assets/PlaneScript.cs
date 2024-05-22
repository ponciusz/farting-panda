using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public PlayerInputActions playerControls;
    public float engineStrength = 1;

    private InputAction fly;

    void Awake()
    {
        playerControls = new PlayerInputActions();

    }

    private void OnEnable()
    {
        fly = playerControls.Player.Fly;
        fly.Enable();
        fly.performed += Fly;
    }

    private void OnDisable()
    {
        fly.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // myRigidbody.velocity = moveDirection * 1 * engineStrength;

    }

    private void Fly(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");
        myRigidbody.velocity = Vector2.up * 3;
    }
}
