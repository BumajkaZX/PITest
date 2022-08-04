using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        LoadController.ChangeScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}