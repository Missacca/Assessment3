using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Zombie : MonoBehaviour
{ 
    public int maxHealth = 3; 
    private int currentHealth; // 当前血量
    private bool isDead = false;
    public Scores s;
    public Transform target;
    public float speed = 3.0f;
     void Start()
    {
        currentHealth = maxHealth; 
        s= FindObjectOfType<Scores>(); 
    }

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

     public void TakeDamage(int damageAmount)
    {
        if (isDead) // 如果敌人已经死亡，退出方法
            return;

        currentHealth -= damageAmount; // 减去伤害值

        // 更新 UI、播放特效等，这里做你需要的额外处理

        if (currentHealth <= 0) // 如果当前血量小于等于 0，敌人死亡
        {
            Die(); // 执行死亡逻辑
        }
    }

     void Die()
    {
        isDead = true; // 设置为死亡状态

        // 增加分数
        if (s != null)
        {
            s.AddScore(1);
        }

        // 执行死亡动画、播放音效等，这里做你需要的额外处理

        // 在此示例中，简单地销毁敌人对象
        Destroy(gameObject);
    }
}
