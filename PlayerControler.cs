using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public GameObject BulletPrefab;
    private Transform gunLeft;
    public float acceleration = 10;
    private Rigidbody rb;
    private Vector2 controls;
    private bool firebuttondown = false;
    private Wyjazd cs;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        gunLeft = transform.Find("gunLeft");
        cs = Camera.main.GetComponent<Wyjazd>();
    }

    // Update is called once per frame
    void Update()
    {
        float v, h;
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        float maxHorizontal = cs.worldWidth / 2;
        float maxVertical = cs.worldHeight / 2;
        
         
        controls = new Vector2(h, v);
        if (Mathf.Abs(transform.position.x) > maxHorizontal) 
        {
            Vector3 newPos = new Vector3(transform.position.x* -0,95f, transform.position.z );
            transform.position= newPos;
        }
        if(Mathf.Abs(transform.position.z) > maxVertical)
        {
            Vector3 newPos = new Vector3(transform.position.x, 0, transform.position.z * -   0.95f);
            transform.position = newPos;
        }
        if(Input.GetKeyDown(KeyCode.Space)) { 
        firebuttondown= true;
        }
    }
    private void FixedUpdate()
    {
      
      rb.AddForce(transform.forward*controls.y,ForceMode.Acceleration);
        rb.AddTorque(transform.up * controls.x * acceleration,ForceMode.Acceleration);

        
        if (firebuttondown) { GameObject Bullet = Instantiate(BulletPrefab, gunLeft.position, Quaternion.identity);
            Bullet.transform.parent = null;
            Bullet.GetComponent<Rigidbody>().AddForce(BulletPrefab.transform.forward *10 ,ForceMode.VelocityChange);
            Destroy(Bullet, 5);
            firebuttondown= false;
        }
        
    }
}
