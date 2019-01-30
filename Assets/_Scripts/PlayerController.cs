using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 MyScale;
    private Rigidbody2D rb;
    public LayerMask layer;
    public float speed = 3;

	void Start ()
    {
        MyScale = this.transform.localScale;
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
            MyScale.x = 2;
            this.transform.localScale = MyScale;
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-speed * Time.deltaTime, 0, 0);
            MyScale.x = -2;
            this.transform.localScale = MyScale;
        }

        if (Input.GetKey(KeyCode.Space) && isgrounded())
        {
            rb.AddForce(Vector2.up * 100);
        }
    }

    bool isgrounded()
    {
        if(Physics2D.Raycast(this.transform.position, Vector2.down, 1f, layer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}