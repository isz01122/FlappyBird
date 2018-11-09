using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour 
{
    public float endOffset;
    private float scrollSpeed = -4.0f;
    Rigidbody2D rb2D;

	void Start () 
    {
        rb2D = GetComponent<Rigidbody2D>();
        //cuz kinematic, velocity is same
        rb2D.velocity = new Vector2(scrollSpeed, 0f);
	}
	

	void Update () 
    {
        //scrollSpeed = -2.0f;
        //if position of x is lower than offset, move to front
        if (transform.position.x <= endOffset)
        {
            float width = GetComponent<BoxCollider2D>().size.x;
            Vector3 pos = transform.position;
            pos.x += width * 2 - 0.01f;
            transform.position = pos;
        }
    }
}
