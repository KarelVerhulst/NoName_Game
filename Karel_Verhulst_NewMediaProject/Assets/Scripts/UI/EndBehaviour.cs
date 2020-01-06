using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndBehaviour : MonoBehaviour
{

    /*
     * if the character reach the end the screen will fade in and after some seconds you go back to the startscreen
     */

    [SerializeField]
    private float _waitTimer = 5;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BaseCharacterBehaviour>(out BaseCharacterBehaviour character))
        {
            this.GetComponent<FadeInOut>().FadeIn();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<BaseCharacterBehaviour>(out BaseCharacterBehaviour character))
        {
            // after some time the scene change to the start screen
            _waitTimer -= Time.deltaTime;

            if (_waitTimer <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    
}
