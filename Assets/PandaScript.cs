using UnityEngine;
using UnityEngine.InputSystem;

public class PandaScript : MonoBehaviour
{


    [SerializeField] private float _fartAnimDuration = 1;
    private float _lockedTill;
    private bool _fartTriggered;
    private Animator _anim;

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

    private void Fly(InputAction.CallbackContext context)
    {
        if (pandaIsAlive)
        {
            source.PlayOneShot(fartSound);
            _fartTriggered = true;
            Debug.Log("Fly");
            myRigidbody.velocity = Vector2.up * engineStrength;
        }


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Game Over");
        logic.GameOver();
        pandaIsAlive = false;
    }


    private int GetState()
    {


        if (Time.time < _lockedTill)
        {
            print(_lockedTill);
            return _currentState;
        }

        // Priorities
        if (_fartTriggered) return LockState(Fart, _fartAnimDuration);
        print(Time.time);
        return Idle;


        int LockState(int s, float t)
        {

            _lockedTill = Time.time + t;
            return s;
        }
    }

    private int _currentState;
    private static readonly int Idle = Animator.StringToHash("idle_animation");
    private static readonly int Fart = Animator.StringToHash("fart_animation");


}
