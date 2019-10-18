using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        
    }

    // LateUpdate is called after Update
    void Update()
    {
        if (InputController.IsSelectButtonPressed())
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

    }
}
