using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Zombie : MonoBehaviour
{ public Transform target;
    public float speed = 3.0f;

    void Update()
    {
        if (target != null)
        {
            MoveTowardsTarget();
        }
    }

    void MoveTowardsTarget()
    {
        // Calculate direction towards the target
        Vector3 direction = (target.position - transform.position).normalized;

        // Move towards the target
        transform.position += direction * speed * Time.deltaTime;

        // Rotate towards the target (optional)
        transform.LookAt(target.position);
    }
}
