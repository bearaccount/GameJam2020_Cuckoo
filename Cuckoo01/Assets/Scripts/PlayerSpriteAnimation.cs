﻿using UnityEngine;

public class PlayerSpriteAnimation : MonoBehaviour
{
    public GameObject player;
    public bool loop;
    public float frameSeconds = 1;
    public bool FixedAnimate = false;
    public float moveAmountThreshold = 0.1f;

    //The file location of the sprites within the resources folder
    //public string location;
    private SpriteRenderer spr;
    private Sprite[] spritesRun;
    private Sprite[] spritesJump;
    private Sprite[] spritesDie;
    private Sprite[] sprites;
    private int frame = 0;
    private float deltaTime = 0;
    private float moveAmount = 0;

    public bool facingRight = true;            // For determining which way the player is currently facing.
    public float moveForce = 40f;            // Amount of force added to move the player left and right.
    public float maxSpeed = 5f;                // The fastest the player can travel in the x axi

    private string moveInputAxis = "Horizontal";
    private Vector3 positionLast;

    private bool isGrounded = true;
    private bool isFinished = false;

    //private Rigidbody rigidBody;

    // Use this for initialization
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();

        spritesRun = Resources.LoadAll<Sprite>("robot_walking_blood_hr");
        Debug.Log($"spritesRun Length: {spritesRun.Length}");

        spritesJump = Resources.LoadAll<Sprite>("robot_jump");
        Debug.Log($"spritesJump Length: {spritesJump.Length}");

        spritesDie = Resources.LoadAll<Sprite>("robot_die");
        Debug.Log($"spritesDie Length: {spritesDie.Length}");

        positionLast = transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        //Keep track of the time that has passed
        deltaTime += Time.deltaTime;

        isGrounded = player.GetComponent<PlayerControllerTransform>().isGrounded;

        isFinished = player.GetComponent<PlayerControllerTransform>().isFinished;

        if (isFinished)
        {
            sprites = spritesDie;
        }
        else if (isGrounded)
        {
            sprites = spritesRun;
        }
        else
        {
            sprites = spritesJump;
        }

        if (FixedAnimate)
        {
            /*Loop to allow for multiple sprite frame 
             jumps in a single update call if needed
             Useful if frameSeconds is very small*/
            while (deltaTime >= frameSeconds)
            {
                deltaTime -= frameSeconds;
                frame++;
                if (loop)
                    frame %= sprites.Length;
                //Max limit
                else if (frame >= sprites.Length)
                    frame = sprites.Length - 1;
            }

        }
        else // animate based off of player movement
        {
            float xDiff = transform.position.x - positionLast.x;
            //Debug.Log($"xDiff: {xDiff}");

            if (xDiff > 0) // right direction
            {
                if (facingRight == true)
                    spr.flipX = false;
                else
                    spr.flipX = true;
            }
            else if(xDiff < 0) // left direction
            {
                if (facingRight == true)
                    spr.flipX = true;
                else
                    spr.flipX = false;
            }

            float positionDelta = (transform.position - positionLast).magnitude;

            //Debug.Log($"positionDelta: {positionDelta}");
            //float speed = positionDelta / Time.deltaTime;
            positionLast = transform.position;

            moveAmount += positionDelta;
            if (moveAmount > moveAmountThreshold)
            {
                frame++;
                if (loop)
                    frame %= sprites.Length;
                //Max limit
                else if (frame >= sprites.Length)
                    frame = sprites.Length - 1;
                moveAmount = 0; // reset
            }


            //rigidBody = player.GetComponent<Rigidbody>;
#if false
            // Cache the horizontal input.
            float moveAxis = Input.GetAxis(moveInputAxis);
            //Debug.Log($"moveaxis: {moveAxis}");

            moveAmount += moveAxis;
            if (moveAmount > moveAmountThreshold)
            {
                frame++;
                if (loop)
                    frame %= sprites.Length;
                //Max limit
                else if (frame >= sprites.Length)
                    frame = sprites.Length - 1;
            }
        
#endif

        }
        //Animate sprite with selected frame
        spr.sprite = sprites[frame];
    }
}