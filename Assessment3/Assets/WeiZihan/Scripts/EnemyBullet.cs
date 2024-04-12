using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{ 
    public GameObject playerExp;
    public GameObject bulletImpact;
    public GameObject gameControllerObj;
    private GameController gc;
    private void Start()
    {
        gameControllerObj = GameObject.FindGameObjectWithTag("GameController");
        gc = gameControllerObj.GetComponent<GameController>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(playerExp, other.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Instantiate(bulletImpact, this.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            gc.gameover();
            
        }


        

    }
}
