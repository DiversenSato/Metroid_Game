using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float enemySpeed;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        this.transform.position = Vector3.Lerp(pointA.position, pointB.position, Mathf.PingPong(Time.time * enemySpeed, 1));
	}
}