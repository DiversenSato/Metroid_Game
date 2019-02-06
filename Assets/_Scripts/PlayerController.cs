using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 MyScale;
    private Rigidbody2D rb;
    public LayerMask layer;
    public float speed = 3;
    public float jumpHeight = 3;
    public GameObject ChungusTheBig;
    private bool isFacingRight;
    public float ShootingSpeed = 6;

	void Start ()
    {
        isFacingRight = true;
        MyScale = this.transform.localScale;
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        Movement();
        ShootSystem();
    }

    private void ShootSystem()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject go = Instantiate(ChungusTheBig, this.transform.position, Quaternion.identity);
            Rigidbody2D rbgo = go.GetComponent<Rigidbody2D>();

            if (isFacingRight)
            {
                Vector2 dir = Vector2.right;
                rbgo.velocity = dir * ShootingSpeed;
            }
            else
            {
                Vector2 dir = Vector2.left;
                rbgo.velocity = dir * ShootingSpeed;
            }
        }
    }


    private void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
            MyScale.x = 2;
            this.transform.localScale = MyScale;
            isFacingRight = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-speed * Time.deltaTime, 0, 0);
            MyScale.x = -2;
            this.transform.localScale = MyScale;
            isFacingRight = false;
        }

        if (Input.GetKey(KeyCode.Space) && isgrounded())
        {
            rb.AddForce(Vector2.up * jumpHeight);
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