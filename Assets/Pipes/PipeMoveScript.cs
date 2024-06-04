using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{

    public LogicScript logic;

    public float deadZOne = -30;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {


        transform.position = transform.position + Vector3.left * logic.gameSpeed * Time.deltaTime;

        if (transform.position.x < deadZOne)
        {
            Destroy(gameObject);
        }
    }
}
