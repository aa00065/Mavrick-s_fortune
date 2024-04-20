using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;




public class SpaceshipController : MonoBehaviour
{

    public float speed = 5f;
    public float speedlvl = 1;
    private Camera mainCamera;
    private bool isDragging = false;
    public Image fuelBarMask;
    public float maxFuel = 10;
    public float maxFuellvl = 1;

    public float fuelConsumptionSpeed = 0.1f;
 
    float currentFuel;
    Vector2 touchPos;
    Rigidbody2D rb2d;
    float startPos;
    float longestDstTravelled = 0;
    public TextMeshProUGUI dstTravelledTXT;


    public GameObject bullet;
    public GameObject bulletposition;
    public GameObject bulletposition2;
    public float bulletInterval = 0.5f; // Adjust this value to change the interval between bullets
    public float lastBulletTime = 0f;

    public ParticleSystem Ship_PS;





    public void ConsumeFuel()
    {
        currentFuel -= fuelConsumptionSpeed; // currentFuel = currentFuel - fuelConsumptionSpeed;

        float fill = currentFuel / (maxFuel +maxFuellvl);
        fuelBarMask.fillAmount = fill;
    }
    public void AddFuel(float _fuelRefillAmount)
    {
        currentFuel += (maxFuel +maxFuellvl) * _fuelRefillAmount;
        if (currentFuel > maxFuel+ maxFuellvl)
        {
            currentFuel = maxFuel + maxFuellvl;
        }
    }

        public void DistanceTravelled()
    {
        float currentDstTravelled = this.transform.position.y - startPos;
        if (currentDstTravelled < 0)
        {
            currentDstTravelled = 0;
        }
        if (currentDstTravelled > longestDstTravelled)
        {
            longestDstTravelled = currentDstTravelled;
        }

        dstTravelledTXT.text = currentDstTravelled.ToString("F1") + " m";

        if (currentFuel <= 0 && rb2d.velocity.y <= 0)
        {
            GameManager.instance.PauseGame();
            GameManager.instance.Addcoins(longestDstTravelled);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        currentFuel = maxFuel + maxFuellvl;
        rb2d = GetComponent<Rigidbody2D>();
        startPos = this.transform.position.y;
        longestDstTravelled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GamePaused)
            DistanceTravelled();
        if (!GameManager.instance.GamePaused)
            if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

                // If the touch phase is began or moved, and the touch is within the screen boundaries
                if (Input.touchCount > 0)
                {
               

                    if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
                    {
                        Vector3 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);
                        touchPosition.z = 0f;
                        transform.position = touchPosition;
                        ConsumeFuel();
                        Ship_PS.Play();

                        if (Time.time - lastBulletTime >= bulletInterval)
                        {
                            GameObject bullet1 = Instantiate(bullet, bulletposition.transform.position, Quaternion.identity);
                            GameObject bullet2 = Instantiate(bullet, bulletposition2.transform.position, Quaternion.identity);

                            lastBulletTime = Time.time;
                        }
                    }
                }

            }
    }
}