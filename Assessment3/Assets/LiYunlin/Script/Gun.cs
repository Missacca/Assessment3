using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Gun : MonoBehaviour
{
    float speeds;
    void Start(){
        Destroy(gameObject,2);
    }
    void Update(){
        transform.Translate(Vector3.forward*speeds*Time.deltaTime);
    }
    public void SetSpeed(float newSpeed)=>speeds = newSpeed;
}
