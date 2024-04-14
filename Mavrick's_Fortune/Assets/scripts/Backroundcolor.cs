using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BackgroundColor : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Color[] bgcolor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Generate();
    }

    public void Generate()
    {
        int colorSelected = Random.Range(0, bgcolor.Length);
        if (bgcolor.Length > 0)
        {
            spriteRenderer.color = bgcolor[colorSelected];
        }
    }


// Update is called once per frame
void Update()
    {
        
    }
}
