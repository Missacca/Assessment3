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
        //      SceneManager.LoadScene(sceneName);
        StartCoroutine("PlayMySound", sceneName); // call the method
    }

    IEnumerator PlaySound(string sceneName)
    {
        yield return new WaitForSeconds(2); // Wait for seconds
        SceneManager.LoadScene(sceneName); // Change the scene
    }

}
