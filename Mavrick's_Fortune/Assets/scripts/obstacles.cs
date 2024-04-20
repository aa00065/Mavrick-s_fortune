using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstackle : MonoBehaviour
{
    public GameObject explosion;

    void playexplosion()
    {
        GameObject boom = Instantiate(explosion);
        boom.transform.position = transform.position;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" )
        {
            playexplosion();
            Destroy(collision.gameObject);
            Destroy(gameObject);
      
            GameManager.instance.gameover();
        }
    }
}