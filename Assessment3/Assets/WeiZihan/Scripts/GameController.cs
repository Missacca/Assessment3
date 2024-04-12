using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject enemy;
    public Vector3 spawnValues;
    public int asteroidNumber;
    public int enemyNumber;
    public float spawnInterval;
    public float startTime;
    public float roundInterval;

    private int score;
    public TextMeshProUGUI counterText;

    bool gameoverFlag;
    public GameObject panel;


    // X max = 50     X min = -50
    // Z = 65
    // Start is called before the first frame update
    void Start()
    {
        counterText.text = "Score: 0";
        StartCoroutine(spawnWaves());
    }
    IEnumerator spawnWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(startTime);
            for(int i = 0 ; i < asteroidNumber ; i++ )
            {
                Vector3 position = new Vector3(Random.Range(-spawnValues.x, spawnValues.x),spawnValues.y, spawnValues.z);
                Instantiate(asteroid, position, Quaternion.identity);
                
                yield return new WaitForSeconds(spawnInterval);
            }
            for(int i=0; i< enemyNumber; i++)
            {
                Vector3 position = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(enemy, position, Quaternion.Euler(0,180,0));
                yield return new WaitForSeconds(spawnInterval);
            }
            yield return new WaitForSeconds(roundInterval);

            if (gameoverFlag)
            {
                panel.SetActive(true);
            }
        }
    }
    public void gameover()
    {
        gameoverFlag = true;
    }
    public void addScore(int num)
    {
        score += num;
        updateCounter();
    }
    void updateCounter() 
    {
        counterText.text = "Score: " + score;
    }
}
