using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent((typeof(PlayerControl)))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 5;
    private Vector3 inputMove;
    private Vector3 moveVelocity;
    private Plane plane;
    private GunController gun;
    PlayerControl controller;
    void Start()
    {
        controller= GetComponent<PlayerControl>();
        plane = new Plane(Vector3.up, Vector3.zero);
        gun = GetComponent<GunController>();
    }
   
    void Update()
    {
        //Move
        inputMove=new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        moveVelocity=moveSpeed*inputMove;
        controller.Move(moveVelocity);
       //follow the mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float f;
        if(plane.Raycast(ray,out f))
        {
            Debug.DrawLine(ray.origin, ray.GetPoint(f),Color.red);
            controller.LookAt(ray.GetPoint(f));
        }
        //shoot
        if(Input.GetMouseButton(0)){
            gun.Shoot();
        }
    }
}
