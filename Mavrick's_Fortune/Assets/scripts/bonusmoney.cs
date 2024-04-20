using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMoney : MonoBehaviour
{
    public float bonusMoney = 5;
    public ParticleSystem ps;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.Addcoins(bonusMoney);
            Instantiate(ps, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}