using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour
{
    public GameObject asteroidExp;
    public GameObject playerExp;
    public GameObject bulletImpact;
    public int health;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
            return;
        if (other.gameObject.CompareTag("bullet"))
            Instantiate(bulletImpact, other.transform.position, Quaternion.identity);
        health--;
        if(health <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(asteroidExp, this.transform.position, Quaternion.identity);

        }


        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(playerExp, other.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Instantiate(asteroidExp, this.transform.position, Quaternion.identity);
        }


        Destroy(other.gameObject);

    }

}
