using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Zombie : MonoBehaviour
{ 
    public int maxHealth = 3; 
    private int currentHealth=3; // 当前血量
    private bool isDead = false;
    public Transform target;
    public float speed = 3.0f;
    private Rigidbody rb;
    private Scores scores;
    public float knockbackForce = 3f;
    public UnityEngine.UI.Image Bar;
    private RectTransform imageRectTransform;
    private Animator animator;
    public AudioSource attatch;
    
     void Start()
    {
         rb = GetComponent<Rigidbody>();
         scores = FindObjectOfType<Scores>();
         imageRectTransform = Bar.GetComponent<RectTransform>();
          animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target != null)
        {
            MoveTowardsTarget();
        }
        BarFill();
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        imageRectTransform.position = screenPos;
    }
    public void TakeDamage(int damageAmount)
    {
        if (isDead)
            return;
            Vector3 knockbackDirection = -transform.forward; // 向后退的方向为僵尸当前朝向的反方向
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse); // 施加向后退的力
        
        this.currentHealth -= damageAmount;


        if (this.currentHealth <= 0) 
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true; 
        animator.SetTrigger("Dead");
        Invoke("Kill",speed/2);
          if (scores != null)
        {
            scores.AddScore(1); 
        }
    }
    void Kill(){
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet")) 
        {
            attatch.Play();
            TakeDamage(1); // 收到伤害
        }
    }
    void MoveTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(target.position);
    } 
    private void BarFill(){
        Bar.fillAmount=Mathf.Lerp(Bar.fillAmount,(float)currentHealth / maxHealth,speed*Time.deltaTime) ;
    }
    
}
