using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Player;
    public Vector3 startPosition;
    public LayerMask playerLayer;
    public Transform pointA;
    public Transform pointB;

    public float EnemySightRange = 4;
    public float chaseDistance = 10;
    public float chaseSpeed;
    public float enemySpeed;
    public bool isChasing = false;

    private bool isPatrolling;
    private Vector2 rayDirection;
    private float transitionT;
    private Vector3 startChasePosition;

	void Start ()
    {
        isPatrolling = true;
        Player = GameObject.FindGameObjectWithTag("Player");
        startPosition = this.transform.position;
	}
	
	void Update ()
    {
        //If our raycast hits the player, then we chase after them
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, rayDirection, EnemySightRange, playerLayer);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                isChasing = true;
                isPatrolling = false;
                startChasePosition = this.transform.position;
            }
        }

        //Our chasing code. Else, we do our patrolling
        if (isChasing == true)
        {
            Debug.Log("Chasing");
            this.transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, Time.deltaTime * chaseSpeed);
        }

        //If we get too far from the Player, we resume our patrolling duties
        float distanceFromOrigin = Vector3.Distance(Player.transform.position, this.transform.position);

        if (distanceFromOrigin >= chaseDistance)
        {
            isChasing = false;
        }

        //Transition back to patrolling phase
        if (isChasing == false && isPatrolling == false)
        {
            this.transform.position = Vector3.Lerp(transform.position, startChasePosition, Time.deltaTime * enemySpeed * 2);

            if (Vector3.Distance(transform.position, startChasePosition) <= 0.1f)
            {
                isPatrolling = true;
            }
        }

        //Our patrolling code
        if (isChasing == false && isPatrolling == true)
        {
            Debug.Log("Sato");

            float t = Mathf.PingPong(Time.time * enemySpeed, 1);
            this.transform.position = Vector3.Lerp(pointA.position, pointB.position, t);

            if (t > 0.95f)
            {
                Vector3 scale = this.transform.localScale;
                scale.x = -0.5f;
                this.transform.localScale = scale;
                rayDirection = Vector2.left;
            }

            if (t < 0.05f)
            {
                Vector3 scale = this.transform.localScale;
                scale.x = 0.5f;
                this.transform.localScale = scale;
                rayDirection = Vector2.right;

            }
        }


    }
}