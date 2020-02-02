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

    public bool isFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionEnter(Collision col)
    {
#if false
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("OnCollisionEnter: " + gameObject.name);
            Debug.Log("Hit");
            //enemyHit = true;
            //other.gameObject.GetComponent<EnemyHealthScript>().EnemyTakeDamage();
        }
#endif

        if (col.gameObject.tag == "Finish")
        {
            Debug.Log("OnCollisionEnter finish: " + gameObject.name);
            isFinished = true;
            //enemyHit = true;
            //other.gameObject.GetComponent<EnemyHealthScript>().EnemyTakeDamage();
        }

        if (col.gameObject.tag == "Ground")
        {
            //Debug.Log("OnCollisionEnter: " + gameObject.name);
            isGrounded = true;
            //enemyHit = true;
            //other.gameObject.GetComponent<EnemyHealthScript>().EnemyTakeDamage();
        }
    }

#if false
    void OnCollisionStay()
    {
        isGrounded = true;
    }
#endif

    // Update is called once per frame
    void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        //transform.Translate(Vector3.right * moveAxis * moveSpeed);
        rb.AddForce(transform.right * moveAxis * moveSpeed, ForceMode.Force);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }


    }
}
