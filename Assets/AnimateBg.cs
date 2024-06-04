using UnityEngine;

public class AnimateTiles : MonoBehaviour
{

    private Material currentTile;
    public float speed;
    private float offset;

    public LogicScript logic;


    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }


    // Update is called once per frame
    void Update()
    {
        if (logic.gameSpeed > 0)
        {
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * speed, 0f);
        }


    }
}
