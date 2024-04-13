using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
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
        Time.timeScale = 1f;
        yield return new WaitForSeconds(2); // Wait for seconds
        SceneManager.LoadScene(sceneName); // Change the scene
    }

}
