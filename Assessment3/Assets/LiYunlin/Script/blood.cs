using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class blood : MonoBehaviour
{
     public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void NextGame()
    { 
         Time.timeScale = 1;
        SceneManager.LoadScene("IntroKun");
    }
    public void MenuTo()
    {
        SceneManager.LoadScene("Menu");
          Time.timeScale = 1;
    }
   
}
