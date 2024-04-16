/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shipcontroller : MonoBehaviour
{
    public Image fuelBarMask;
    public float maxFuel = 10;
    public float fuelConsumptionSpeed = 0.1f;
    public float thrustForce = 10;
    public float strafeSpeed = 5;
    public float upDownSpeed = 5;
    float currentFuel;
    Vector2 touchPos;
    Rigidbody2D rb2d;
    Camera mainCamera;

    void Start()
    {
        currentFuel = maxFuel;
        rb2d = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;

        void FixedUpdate()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        touchPos = mainCamera.ScreenToWorldPoint(touch.position);
                        break;
                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        touchPos = mainCamera.ScreenToWorldPoint(touch.position);
                        MoveShip();
                        AddThrustForce();
                        break;
                    case TouchPhase.Ended:
                        break;
                }
            }
        }

        void MoveShip()
        {
            Vector2 targetPosition = new Vector2(touchPos.x, touchPos.y);
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);

            if (currentFuel > 0)
            {
                // Calculate movement direction
                Vector2 moveDirection = (targetPosition - currentPosition).normalized;

                // Calculate movement distance based on speed
                float moveDistance = upDownSpeed * Time.fixedDeltaTime;

                // Move towards the target position
                rb2d.MovePosition(currentPosition + moveDirection * moveDistance);

                ConsumeFuel();
            }
        }

        void AddThrustForce()
        {
            if (currentFuel > 0)
            {
                Vector2 _thrustForceVector = new Vector2(0, thrustForce);
                rb2d.AddForce(_thrustForceVector);
                ConsumeFuel();
            }
        }

        void ConsumeFuel()
        {
            currentFuel -= fuelConsumptionSpeed;

            float fill = currentFuel / maxFuel;
            fuelBarMask.fillAmount = fill;
        }
    }
}
*/