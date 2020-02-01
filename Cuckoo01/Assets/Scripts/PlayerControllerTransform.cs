using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTransform : MonoBehaviour
{
    private string moveInputAxis = "Horizontal";
    public float moveSpeed = 20;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    private Rigidbody rb;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        //transform.Translate(Vector3.right * moveAxis * moveSpeed);
        //rb.AddForce(transform.right * moveAxis * moveSpeed * Time.deltaTime, ForceMode.Force);
        rb.AddForce(transform.right * moveAxis * moveSpeed, ForceMode.Force);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }


    }
}
