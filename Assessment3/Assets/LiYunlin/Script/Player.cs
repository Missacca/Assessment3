using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent((typeof(Rigidbody)))]
public class Player : MonoBehaviour
{
    public float moveSpeed=5;
    private Rigidbody rig;
    Plane plane;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        plane = new Plane(Vector3.up, Vector3.zero);
    }
    // Update is called once per frame
    void Update()
    {
        //Move
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
       if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
        }

       //follow the mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float f;
        if(plane.Raycast(ray,out f))
        {
            Debug.DrawLine(ray.origin, ray.GetPoint(f),Color.red);
        }
    }
}
