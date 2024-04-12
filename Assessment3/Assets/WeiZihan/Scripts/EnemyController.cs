using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody rb;

    public GameObject bullet;
    public GameObject shotSpawn;
    public float speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        StartCoroutine(EnemyFire());
    }

    IEnumerator EnemyFire()
    {
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(bullet, shotSpawn.transform.position, Quaternion.identity);
        }
    }

}
