using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBird : MonoBehaviour 
{
    //public Vector2 float jumpForce=200.0f; <- this is bad way!!!

    //Avoid to Garbage collection, we can try this way!
    public Vector2 jumpForce = new Vector2(0,200.0f);
    Rigidbody2D rigidBody;
    Animator animator;
    int collisionCount = 0;
    public AudioSource jumpSound;
    public AudioSource dieSound;
    void Start () 
    {
        //This way is Cashing that is skill of unity!
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	void Update () 
    {
        if (GameManager._instance.isReady)
            return;

        rigidBody.gravityScale = 1.0f;
        if (Input.GetMouseButtonDown(0))
            Jump();
	}

    void Jump()
    {
        //rigidBody.AddForce(new Vector2(0, jumpForce)); <- This code is bad, cuz.. it makes garbage collection

        //Cashing is faster than GetComponent
        //If we click the left mouse button, the velocity will be reset to zero.
        rigidBody.velocity = Vector2.zero;
        rigidBody.AddForce(jumpForce);
        animator.SetTrigger("Jump");
        jumpSound.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //How to use Singleton!
        animator.SetTrigger("Die");
        ++collisionCount;
        if (collisionCount == 1)
        {
            dieSound.Play();
            GameManager._instance.GameOver();
            GameManager._instance.column.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager._instance.AddScore();
    }
}
