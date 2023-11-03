using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Main");
        PlayerPrefs.SetInt("KeycardLantai3", 0);
        PlayerPrefs.SetInt("KeycardLantai4", 0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
