using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Transform[] Points;
    public Transform currenttarget;
    public int currentindex;
    
	void Start ()
    {
        currentindex = 0;
        currenttarget = Points[currentindex];
    }
	
	void Update ()
    {
        if (this.transform.position == currenttarget.position)
        {
            currentindex++;

            if (currentindex >= Points.Length)
            {
                currentindex = 0;
            }

            currenttarget = Points[currentindex];


        }

        this.transform.position = Vector3.MoveTowards(this.transform.position, currenttarget.position, speed * Time.deltaTime);
	}
}