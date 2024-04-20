using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class satalite_collision : MonoBehaviour
{   public GameObject explosion;

    void playexplosion()
    {
        GameObject boom = (GameObject)Instantiate(explosion);
        boom.transform.position = transform.position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "bullet")
        {
            playexplosion();
            Destroy(collision.gameObject);
            //play particle system
            Destroy(gameObject);
        }

        

    
}
}
