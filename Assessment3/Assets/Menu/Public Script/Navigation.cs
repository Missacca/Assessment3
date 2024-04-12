using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);

    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(nameof(PlaySound), sceneName); // call the method
    }

    IEnumerator PlaySound(string sceneName)
    {
        Time.timeScale = 1f; // Makesure the time move
        yield return new WaitForSeconds(1); // Wait for seconds
        SceneManager.LoadScene(sceneName); // Change the scene
    }
    public void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
