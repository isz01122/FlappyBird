using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyColumn : MonoBehaviour 
{
    public float speed = -4.0f;
    public float endOffset;

	// Use this for initialization
	void Start () 
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (transform.position.x <= endOffset)
        {
            Destroy(this.gameObject);
        }
    }
}
