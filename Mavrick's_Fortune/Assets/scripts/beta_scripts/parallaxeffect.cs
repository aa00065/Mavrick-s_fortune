using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class parallaxeeffect : MonoBehaviour
{
    public float speed = 0.01f;
    public enum Direction { LeftToRight, RightToLeft, DownToUp, UpToDown };
    public Direction direction;
    public float limitOffScreen = 1f;
    public bool regenerateOnExit = true;

    private Vector3 startPosition;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        startPosition = transform.position;
    }

    void Update()
    {
        float cameraScroll = GetCameraScroll();
        transform.position += GetSpeedVector() * cameraScroll;

        if (IsObjectOffScreen())
        {
            if (regenerateOnExit)
            {
                transform.position = GetRegeneratePosition();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    float GetCameraScroll()
    {
        return (direction == Direction.LeftToRight || direction == Direction.DownToUp) ?
            mainCamera.transform.position.x - startPosition.x :
            mainCamera.transform.position.y - startPosition.y;
    }

    Vector3 GetSpeedVector()
    {
        return (direction == Direction.LeftToRight) ? Vector3.right * speed :
               (direction == Direction.RightToLeft) ? Vector3.left * speed :
               (direction == Direction.DownToUp) ? Vector3.up * speed :
               Vector3.down * speed;
    }

    bool IsObjectOffScreen()
    {
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(transform.position);
        return (direction == Direction.LeftToRight && viewportPoint.x < -limitOffScreen) ||
               (direction == Direction.RightToLeft && viewportPoint.x > 1f + limitOffScreen) ||
               (direction == Direction.DownToUp && viewportPoint.y < -limitOffScreen) ||
               (direction == Direction.UpToDown && viewportPoint.y > 1f + limitOffScreen);
    }

    Vector3 GetRegeneratePosition()
    {
        float x = (direction == Direction.LeftToRight) ? 1f + limitOffScreen :
                  (direction == Direction.RightToLeft) ? -limitOffScreen :
                  Random.Range(0f, 1f);
        float y = (direction == Direction.DownToUp) ? 1f + limitOffScreen :
                  (direction == Direction.UpToDown) ? -limitOffScreen :
                  Random.Range(0f, 1f);
        return mainCamera.ViewportToWorldPoint(new Vector3(x, y, 10f));
    }
}

