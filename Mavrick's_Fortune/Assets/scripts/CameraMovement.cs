using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    // Set the initial speed that the camera moves through space
    public float initialCameraSpeed = 8f;
    // Set the rate at which the camera speed increases
    public float speedIncreaseRate = 1f;
    // Variable to keep track of the elapsed time
    float elapsedTime = 0f;
    public float cameraSpeed = 8f;
    float currentScrollPosition = 0f;
    void Start()
    {
        // Set the initial camera speed
        cameraSpeed = initialCameraSpeed;

        // Calculate the initial scroll position based on the camera speed
        switch (SpaceManager.instance.scrollDirection)
        {
            case ScrollDirection.LeftToRight:
            case ScrollDirection.RightToLeft:
                currentScrollPosition = transform.position.x / cameraSpeed;
                break;
            case ScrollDirection.DownToUp:
            case ScrollDirection.UpToDown:
                currentScrollPosition = transform.position.y / cameraSpeed;
                break;
        }
    }

    void Update()
    {
        // Increase the elapsed time
        elapsedTime += Time.deltaTime;
        // Increase the camera speed gradually
        cameraSpeed += speedIncreaseRate * Time.deltaTime;

        // Calculate the new position based on the updated camera speed
        currentScrollPosition += Time.deltaTime;
        Vector3 newPosition = Vector3.zero;
        switch (SpaceManager.instance.scrollDirection)
        {
            case ScrollDirection.LeftToRight:
                newPosition = new Vector3(Mathf.Lerp(transform.position.x, cameraSpeed * currentScrollPosition, 1f * Time.deltaTime), transform.position.y, transform.position.z);
                break;
            case ScrollDirection.RightToLeft:
                newPosition = new Vector3(Mathf.Lerp(transform.position.x, -cameraSpeed * currentScrollPosition, 1f * Time.deltaTime), transform.position.y, transform.position.z);
                break;
            case ScrollDirection.DownToUp:
                newPosition = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, cameraSpeed * currentScrollPosition, 1f * Time.deltaTime), transform.position.z);
                break;
            case ScrollDirection.UpToDown:
                newPosition = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, -cameraSpeed * currentScrollPosition, 1f * Time.deltaTime), transform.position.z);
                break;
        }
        transform.position = newPosition;
    }
}
