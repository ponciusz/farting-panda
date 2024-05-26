using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PandaScript : MonoBehaviour
{
    public AudioSource source;
    public AudioClip fartSound;
    public Rigidbody2D myRigidbody;
    public PlayerInputActions playerControls;
    public float engineStrength = 1;
    public LogicScript logic;
    private InputAction fly;
    public bool pandaIsAlive = true;

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
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }


    // Update is called once per frame
    void Update()
    {

        // myRigidbody.velocity = moveDirection * 1 * engineStrength;

    }

    private void Fly(InputAction.CallbackContext context)
    {
        if (pandaIsAlive)
        {
            source.PlayOneShot(fartSound);
            Debug.Log("Fire");
            myRigidbody.velocity = Vector2.up * engineStrength;
        }


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Game Over");
        logic.GameOver();
        pandaIsAlive = false;
    }
}
