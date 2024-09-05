using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    private bool isGrounded;
    private bool isJumping;

    private Animator catAnimator;
    private AudioSource catSound;

    private CapsuleCollider2D catCollider;
    private Rigidbody2D catRigidbody;
    private Cat cat;

    public float catSpeed;
    public float catjumpForce;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        isJumping = false;

        catAnimator = GetComponent<Animator>();
        catRigidbody = GetComponent<Rigidbody2D>();
        catCollider = GetComponent<CapsuleCollider2D>();
        catSound = GetComponent<AudioSource>(); 
        cat = GetComponent<Cat>();
    }

    //private void FixedUpdate()
    //{
    //    float horizontal = Input.GetAxis("Horizontal");

    //    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    //    {
    //        isGrounded = false;
    //        isJumping = true;

    //        if (horizontal > 0.5f)
    //        {
    //            JumpRight();
    //        }
    //        else if (horizontal < -0.5f)
    //        {
    //            JumpLeft();
    //        }
    //        else
    //        {
    //            if (gameObject.transform.localScale.x > 0)
    //            {
    //                JumpRight();
    //            }
    //            else
    //            {
    //                JumpLeft();
    //            }
    //        }
    //    }
    //    else
    //    {
    //        if (isGrounded)
    //        {
    //            if (horizontal > 0.5)
    //            {
    //                MoveRight();
    //            }
    //            else if (horizontal < -0.5)
    //            {
    //                MoveLeft();
    //            }
    //            else
    //            {
    //                Idle();
    //            }
    //        }
    //    }
    //}

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            isJumping = true;

            if (horizontal > 0.5f)
            {
                JumpRight();
            }
            else if (horizontal < -0.5f)
            {
                JumpLeft();
            }
            else
            {
                if (gameObject.transform.localScale.x > 0)
                {
                    JumpRightUp();
                }
                else
                {
                    JumpLeftUp();
                }
            }
        }
        else
        {
            if (isGrounded)
            {
                if (horizontal > 0.5)
                {
                    MoveRight();
                }
                else if (horizontal < -0.5)
                {
                    MoveLeft();
                }
                else
                {
                    Idle();
                }
            }
        }

        if (Input.GetKeyDown (KeyCode.E))
        {
            cat.InteractWithGameObject();
        }
    }

    private void JumpLeftUp()
    {
        Vector2 jumpVector = new Vector2(0f, catjumpForce);
        catRigidbody.velocity = jumpVector;
    }

    private void JumpRightUp()
    {
        Vector2 jumpVector = new Vector2(0f, catjumpForce);
        catRigidbody.velocity = jumpVector;
    }

    private void Idle()
    {
        catAnimator.SetBool("IsWalking", false);
        catAnimator.SetBool("IsWalkingLeft", false);
        catAnimator.SetBool("IsWalkingRight", false);
        //catRigidbody.velocity = Vector2.zero;
        //catRigidbody.velocity = new Vector2(0, catRigidbody.velocity.y);
    }

    private void MoveLeft()
    {
        catAnimator.SetBool("IsWalking", true);
        catAnimator.SetBool("IsWalkingLeft", true);
        catAnimator.SetBool("IsWalkingRight", false);

        //catRigidbody.AddForce(new Vector2(-1 * catSpeed, catRigidbody.velocity.y), ForceMode2D.Impulse);
        //catRigidbody.AddForce(new Vector2(-1 * catSpeed, 0), ForceMode2D.Impulse);
        catRigidbody.velocity = new Vector2(-1 * catSpeed, catRigidbody.velocity.y);
        gameObject.transform.localScale = new Vector3(-1, 1, 1);
    }

    private void MoveRight()
    {
        catAnimator.SetBool("IsWalking", true);
        catAnimator.SetBool("IsWalkingLeft", false);
        catAnimator.SetBool("IsWalkingRight", true);
        //catRigidbody.AddForce(new Vector2(catSpeed, 0), ForceMode2D.Impulse);
        catRigidbody.velocity = new Vector2(catSpeed, catRigidbody.velocity.y);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    private void JumpLeft()
    {
        //if (catRigidbody.velocity.x > 0.01)


        Vector2 jumpVector = new Vector2(-10.0f, catjumpForce);
        catRigidbody.velocity = jumpVector;
        //catRigidbody.AddForce(jumpVector);
        //gameObject.transform.localScale = new Vector3(-1, 1, 1);
    }

    private void JumpRight()
    {
        Vector2 jumpVector = new Vector2(10.0f, catjumpForce);
        catRigidbody.velocity = jumpVector;

        //catRigidbody.AddForce(jumpVector);
        //gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            if (!isGrounded)
            {
                catSound.Play();
            }

            isGrounded = true;
            isJumping = false;
            //catAnimator.SetBool("IsJumping", false);
            //catRigidbody.velocity = new Vector2(catRigidbody.velocity.x, 0);
        }
    }


}
