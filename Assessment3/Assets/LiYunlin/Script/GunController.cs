using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform m;
    public Gun p;
    public float muzty = 35;
    public float gunshoottime=500;
    float nnshot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Shoot(){
         if(Time.time>nnshot)
         {
            nnshot=Time.time+gunshoottime/100;
            Gun newGun= Instantiate(p,m.position,m.rotation);
            newGun.SetSpeed(muzty);
         }
    }
}
