using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class menu_controller : MonoBehaviour
{
    public void LoadScene(string _name)
    {
        SceneManager.LoadScene(_name);

    }
}

