using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Transform camRef;
    public float scrollSpeed;
    float startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float scrollDST_R = camRef.position.y * (1 - scrollSpeed);
        float scrollDST = camRef.position.y * scrollSpeed;
        transform.position = new Vector2(transform.position.x, startPos + scrollDST);

        if (scrollDST_R > startPos + 12)
        {
            startPos = startPos + 12;
        }
        else if (scrollDST_R < startPos - 12)
        {
            startPos = startPos - 12;
        }
    }
}