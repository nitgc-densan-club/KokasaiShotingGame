using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamadaEnemy : MonoBehaviour
{
    public GameObject bullet;
    private float timeElasped;
    public int speed = 2;
    Vector3 force;
    Rigidbody rb;


    void Start()
    {

        rb = this.GetComponent<Rigidbody>();
        force = new Vector3(1.0f, 0.0f, -1.0f) * speed;



    }


    // Update is called once per frame
    void Update()
    {
        timeElasped += Time.deltaTime;

        if (timeElasped >= 5)
        {
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1 ), bullet.transform.rotation);


            timeElasped = 2.0f;
        }
        rb.AddForce(force, ForceMode.Impulse);
    }
}

