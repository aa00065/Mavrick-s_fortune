using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstackle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" )
        {
            GameManager.instance.gameover();
            Destroy(collision.gameObject);
            //play particle system
            Destroy(gameObject);
        }
    }
}