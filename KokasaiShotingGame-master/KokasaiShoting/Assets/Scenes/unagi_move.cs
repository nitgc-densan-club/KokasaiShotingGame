using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    float speed = -0.01f;
    Rigidbody rb;

    float delta=0;
    public GameObject tama;
    Vector3 mypos = new Vector3();
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        mypos = this.transform.position;
        delta += Time.deltaTime;

        if (delta >= 5)
        {
            Instantiate(tama, mypos+new Vector3(), Quaternion.identity);
            delta = 0;
        }
        //進行
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        if (mypos.z <= 0)
        {
            Destroy(this.gameObject);
        }
        
         
	}
}
