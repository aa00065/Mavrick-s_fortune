using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class sceneswitcher : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        ShowMenu();

    }

  

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    // Call this method to switch scenes
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    private void ShowMenu()
    {
        throw new NotImplementedException();
    }
}

