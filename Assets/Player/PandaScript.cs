using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PandaScript : MonoBehaviour
{
    private float _fartAnimDuration = 0.3f;
    private float _lockedTill;
    private bool _fartTriggered;
    private Animator _anim;

    public AudioSource source;
    public AudioClip fartSound;
    public Rigidbody2D myRigidbody;
    public PlayerInputActions playerControls;
    public float fartStrength = 1f;
    public LogicScript logic;
    private bool canFly = true;
    public bool pandaIsAlive = true;

    void Awake()
    {
        playerControls = new PlayerInputActions();
        playerControls.Player.Fly.performed += Fly;
    }

    private void OnEnable()
    {
        playerControls.Player.Enable();
    }

    private void OnDisable()
    {
        playerControls.Player.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        _anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        var state = GetState();

        _fartTriggered = false;

        if (state == _currentState) return;
        _anim.CrossFade(state, 0, 0);
        _currentState = state;

    }

    private int GetState()
    {
        if (Time.time < _lockedTill)
        {
            return _currentState;
        }

        // Priorities
        if (_fartTriggered) return LockState(Fart, _fartAnimDuration);
        return Idle;

        int LockState(int s, float t)
        {
            _lockedTill = Time.time + t;
            return s;
        }
    }


    private void Fly(InputAction.CallbackContext context)
    {
        if (pandaIsAlive && canFly)
        {
            StartCoroutine(FlyExecute());
        }
    }

    private IEnumerator FlyExecute()
    {
        source.PlayOneShot(fartSound);
        _fartTriggered = true;
        myRigidbody.velocity = Vector2.up * fartStrength;
        canFly = false;
        // Wait
        yield return new WaitForSeconds(_fartAnimDuration);
        canFly = true;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        pandaIsAlive = false;
    }




    private int _currentState;
    private static readonly int Idle = Animator.StringToHash("idle_animation");
    private static readonly int Fart = Animator.StringToHash("fart_animation");

}
