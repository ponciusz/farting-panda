using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public AudioSource source;
    public AudioClip pointSound;
    public LogicScript logic;
    public PandaScript panda;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        panda = GameObject.FindGameObjectWithTag("Player").GetComponent<PandaScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 3 && panda.pandaIsAlive)
        {

            source.PlayOneShot(pointSound);
            logic.AddScore(1);
        }
    }
}
