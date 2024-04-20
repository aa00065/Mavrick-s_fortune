using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public TextMeshProUGUI coinsTXT;
    public float coinsBonusMultiplier = 2;
    public float coins { get; set; }
    public bool GamePaused;
    public GameObject gameovermenu;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void Addcoins(float _coinsToAdd)
    {
        _coinsToAdd = Mathf.Round(_coinsToAdd);
        coins += _coinsToAdd * coinsBonusMultiplier;
        coinsTXT.text = coins.ToString() +" coins";
    }

    public void spendcoins(int _coinsTospend)
    {
        
        coins -= _coinsTospend;
        coinsTXT.text = coins.ToString() + " coins";
    }




    public void PauseGame()
    {
        Time.timeScale = 0;
        GamePaused = true;

    }
    public void resumeGame()
    {
        Time.timeScale = 1;
        GamePaused = false;

    }
    public void gameover()
    {
        PauseGame();
        gameovermenu.SetActive(true);
    }
 
    // Start is called before the first frame update
    void Start()
    {
        GamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}