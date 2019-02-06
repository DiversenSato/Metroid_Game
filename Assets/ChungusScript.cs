using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChungusScript : MonoBehaviour {


    private float timer =0;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 5)
        {
            Destroy(this.gameObject);

        }


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player") && !col.gameObject.CompareTag("Bullet"))
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                Destroy(col.gameObject);
            }

            Destroy(this.gameObject);
        }
    }

}
