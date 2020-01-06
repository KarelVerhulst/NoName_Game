using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenBehaviour : MonoBehaviour
{
    /*
     *  methods to do an action on the startscreen
     */

    private void Start()
    {
        Cursor.visible = false;
    }

    public void ChangePanel(GameObject newPanel)
    {
        this.gameObject.SetActive(false);
        newPanel.SetActive(true);
    }

    public void SelectCorrectButton(Button selectButton)
    {
        selectButton.Select();
    }

    public void GoToScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
