using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusfuel : MonoBehaviour
{
    public float refillAmount = 0.2f;
  
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<SpaceshipController>().AddFuel(refillAmount);
            // Play particle system
            Destroy(gameObject);
        }
    }
}



