using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeFuel : MonoBehaviour
{
    public SpaceshipController sc;
    public int cost = 200;
    public TextMeshProUGUI TXT;

    private void Start()
    {
        TXT.text = "MAX FUEL\n" + "LVL: " + sc.maxFuellvl.ToString() + "\n" + cost.ToString() + "$";  
        GameManager.instance.Addcoins(5000);
    }

    public void UpgradeFuelTank()
    {

        if (GameManager.instance.coins > cost)
        {
            sc.maxFuellvl += 1;
            GameManager.instance.spendcoins(cost);
            cost = cost * 3;
            TXT.text = "MAX FUEL\n" + "LVL: " + sc.maxFuellvl.ToString() + "\n" + cost.ToString() + "$";


        }
    }
}