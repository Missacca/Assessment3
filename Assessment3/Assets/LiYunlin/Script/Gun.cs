using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Gun : MonoBehaviour
{
    float speeds;
    float moveD;
    public LayerMask collisionMask;
    void Start(){
        Destroy(gameObject,2);
    }
    void Update(){
        moveD=speeds*Time.deltaTime;
        transform.Translate(Vector3.forward*speeds*Time.deltaTime);
    }
    public void SetSpeed(float newSpeed)=>speeds = newSpeed;
    void checkColsions(float moveD)
    {
        Ray ray=new Ray(transform.position,transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,moveD,collisionMask,QueryTriggerInteraction.Collide)){
            print(hit.collider.name);
            Destroy(gameObject);
        }
    }
}
