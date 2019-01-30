using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public LayerMask playerLayer;
    public Transform pointA;
    public Transform pointB;

    public float chaseSpeed;
    public float enemySpeed;
    public bool isChasing = false;
    public GameObject Player;

	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.left, 2, playerLayer);

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                isChasing = true;   
            }
        }

        if (isChasing == true)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, Time.deltaTime * chaseSpeed);
        }

        if (isChasing == false)
        {
            float t = Mathf.PingPong(Time.time * enemySpeed, 1);
            this.transform.position = Vector3.Lerp(pointA.position, pointB.position, t);

            if (t > 0.95f)
            {
                Vector3 scale = this.transform.localScale;
                scale.x = -0.5f;
                this.transform.localScale = scale;
            }

            if (t < 0.05f)
            {
                Vector3 scale = this.transform.localScale;
                scale.x = 0.5f;
                this.transform.localScale = scale;
            }
        }
    }
}