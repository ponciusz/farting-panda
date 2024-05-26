using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{

    public float moveSpeed = 5;
    public float deadZOne = -30;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed / 5) * Time.deltaTime;

        if (transform.position.x < deadZOne)
        {
            Destroy(gameObject);
        }
    }
}
