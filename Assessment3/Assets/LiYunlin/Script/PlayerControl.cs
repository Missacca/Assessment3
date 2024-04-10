using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    Rigidbody rig;
    Vector3 velocity;
    void Start()
    {
        rig =GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.MovePosition(transform.position+velocity*Time.fixedDeltaTime);
    }
    public void Move(Vector3 velocity){this.velocity=velocity;}
    public void LookAt(Vector3 p){
        Vector3 vector3=new (p.x,transform.position.y,p.z);
        transform.LookAt(vector3);
    }
}
