using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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
    
     void Start()
    {
         rb = GetComponent<Rigidbody>();
         scores = FindObjectOfType<Scores>();
    }

    void Update()
    {
        if (target != null)
        {
            MoveTowardsTarget();
        }
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
        Destroy(gameObject);
          if (scores != null)
        {
            scores.AddScore(1); 
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet")) 
        {
            TakeDamage(1); // 收到伤害
        }
    }
    void MoveTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(target.position);
    } 
}
