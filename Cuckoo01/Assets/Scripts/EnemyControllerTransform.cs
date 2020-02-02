using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerTransform : MonoBehaviour
{
    private string moveInputAxis = "Horizontal";
    public float moveSpeed = 20;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    private Rigidbody rb;
    public bool isGrounded;

    private int count = 0; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }




    // Update is called once per frame
    void Update()
    {
        //float moveAxis = Input.GetAxis(moveInputAxis);
        transform.Translate(Vector3.left * 0.1f * moveSpeed);
        //rb.AddForce(transform.right * moveAxis * moveSpeed, ForceMode.Force);

        count++;
        if (count % 200 == 0)
        { 
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
