using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartf : MonoBehaviour, Heart
{
    protected float health;
    public float StartingHealth;
    protected bool dead= false;
    public Scores scores=new Scores();
    public void TaskHit(float d, RaycastHit h){
        health-=d;
        if(health<=0&& !dead)
        Die();
    }
    protected virtual void  Start()
    {
        health = StartingHealth;
    }

    
    void Update()
    {
        
    }
    protected void Die(){
        dead=true;
        scores.score++;
        Destroy(gameObject);
    }
}
