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
    private int health = 3; 
    public GameObject gameOverPanel;
   
    void Start()
    {
       
        controller= GetComponent<PlayerControl>();
        plane = new Plane(Vector3.up, Vector3.zero);
        gun = GetComponent<GunController>();
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
       
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
     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // 当玩家与敌人发生碰撞时，玩家受到伤害
            TakeDamage(1);
        }
    }
     private void TakeDamage(int damageAmount)
    {
        health -= damageAmount; // 减去伤害值

        if (health <= 0)
        {
            gameOver(); 
        }
    }

    private void gameOver()
    {
         Time.timeScale = 0;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
