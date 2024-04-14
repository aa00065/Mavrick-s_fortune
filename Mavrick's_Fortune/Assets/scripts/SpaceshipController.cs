using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpaceshipController : MonoBehaviour
{
    // Speed of the player's movement
    public float speed = 5f;

    // Reference to the camera for converting screen coordinates to world coordinates
    private Camera mainCamera;

    // Flag to check if the player is currently being dragged
    private bool isDragging = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player using keyboard inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);

        // If the player is using touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // If the touch phase is began or moved, and the touch is within the screen boundaries
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                Vector3 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f;
                transform.position = touchPosition;
            }
        }
    }
}
