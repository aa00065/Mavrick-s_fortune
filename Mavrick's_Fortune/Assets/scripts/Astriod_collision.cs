using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astriod_collision : MonoBehaviour
{   
    public ParticleSystem ps;



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "bullet")
        {
            
            Destroy(collision.gameObject);
            Instantiate(ps,transform.position,transform.rotation);   
            Destroy(gameObject);
        }

        

    
}
}
