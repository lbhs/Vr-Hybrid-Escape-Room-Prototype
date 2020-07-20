using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StarGameScript : MonoBehaviour
{
    public int Sceneindex=1;
    public void StartGame()
    {
        //Hide/lock mouse in the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Screen.fullScreen = true;
        SceneManager.LoadScene(Sceneindex);
    }
}
