using UnityEngine;

public class AnimateTiles : MonoBehaviour
{

    private Material currentTile;
    public float speed;
    private float offset;

    // Update is called once per frame
    void Update()
    {

        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * speed, 0f);
    }
}
