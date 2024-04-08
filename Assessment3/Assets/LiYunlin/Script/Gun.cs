using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEditor;
using UnityEngine;

public class Gun : MonoBehaviour
{
   float speeds;
    float moveD;

    void Start()
    {
        Destroy(gameObject, 2);
    }

    void Update()
    {
        moveD = speeds * Time.deltaTime;
        transform.Translate(Vector3.forward * speeds * Time.deltaTime);
    }

    public void SetSpeed(float newSpeed) => speeds = newSpeed;
}