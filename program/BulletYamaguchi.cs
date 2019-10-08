using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletYamaguchi : MonoBehaviour {

    Rigidbody rb;
    Vector3 force;
    int speed = 7;
    float TimeCount = 3;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        force = new Vector3(0, 0, 1) * speed;
    }
	
	// Update is called once per frame
	void Update () {
        
        rb.AddForce(force, ForceMode.VelocityChange);

        TimeCount -= Time.deltaTime;

        if(TimeCount <= 0)
        {
            //自身を破壊
            Destroy(this.gameObject);
        }
        
	}
}
