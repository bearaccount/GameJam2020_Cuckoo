using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    public float depthOffset = -10f;
    public float verticalOffset = 6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, verticalOffset, depthOffset);
        //transform.position.z = depthOffset;
        //transform.position.y = verticalOffset;
        //transform.position.x = player.transform.position.x;
    }
}
