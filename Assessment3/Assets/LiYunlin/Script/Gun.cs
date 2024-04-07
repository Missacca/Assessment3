using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEditor;
using UnityEngine;

public class Gun : MonoBehaviour
{
   float speeds;
    float moveD;
    public LayerMask collisionMask;
    private Zombie zombieScript;
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, 2);
    }

    void Update()
    {
        moveD = speeds * Time.deltaTime;
        transform.Translate(Vector3.forward * speeds * Time.deltaTime);
        CheckCollisions(moveD);
    }

    public void SetSpeed(float newSpeed) => speeds = newSpeed;

    void CheckCollisions(float moveD)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, moveD, collisionMask, QueryTriggerInteraction.Collide))
        {
            zombieScript = hit.collider.gameObject.GetComponent<Zombie>();

            if (zombieScript != null)
            {
                zombieScript.TakeDamage(damage);
                Destroy(gameObject); // 销毁子弹
            }
        }
    }
}