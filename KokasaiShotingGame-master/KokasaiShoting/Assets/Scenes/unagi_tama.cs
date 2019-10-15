using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tama : MonoBehaviour {

    public int speed = -2;
    float delta = 0;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        Debug.Log(this.transform.position);
   
	}

    // Update is called once per frame
    void Update()
    {
        //オブジェクトに力を加える
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        delta += Time.deltaTime;
        if(delta >= 1)
        {
            Destroy(this.gameObject);
        }

        

    }
}
