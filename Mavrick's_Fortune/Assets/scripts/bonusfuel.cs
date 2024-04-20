using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusfuel : MonoBehaviour
{
    public float refillAmount = 0.2f;
    public ParticleSystem ps;
  
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<SpaceshipController>().AddFuel(refillAmount);
            Instantiate(ps,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}



