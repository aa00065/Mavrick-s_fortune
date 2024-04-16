using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMoney : MonoBehaviour
{
    public float bonusMoney = 5;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.Addcoins(bonusMoney);
            //play particle system
            Destroy(gameObject);
        }
    }
}