using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
    /**
     * X min = -50   X max = 50
     * Z min = -4    Z max = 54
     */
}
public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float moveSpeed;
    public float tile;
    public Boundary boundary;
    public GameObject shotSpawn;
    public GameObject bullet;

    private float myTime;
    private float nextFire;
    public float fireDelta;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        // Get input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        // Move object
        rb.velocity = new Vector3(horizontalInput * moveSpeed, 0, verticalInput * moveSpeed);
        // Limit movement
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax)
            , rb.position.y,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        // Rotation while moving

        rb.rotation = Quaternion.Euler(tile * rb.velocity.z, 0, -(tile* rb.velocity.x));
    }

    private void Update()
    {
        myTime += Time.deltaTime;
        if(Input.GetKey(KeyCode.Space) && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            Instantiate(bullet, shotSpawn.transform.position, Quaternion.identity);
            nextFire -= myTime;
            myTime = 0.0F;
        }
    }
}
