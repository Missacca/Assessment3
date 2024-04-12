using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    public Vector3 spawnValues;
    public int asteroidNumber;
    public float spawnInterval;
    public float startTime;
    public float roundInterval;
    // X max = 50     X min = -50
    // Z = 65
    // Start is called before the first frame update
    void Start()
    {
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
            yield return new WaitForSeconds(roundInterval);
        }
        

    }
}
