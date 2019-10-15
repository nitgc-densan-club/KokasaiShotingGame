using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlYamaguchi : MonoBehaviour {

    float TimeCount = 5;
    public GameObject originObject;
    Rigidbody rb;
    int speed = 0;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        TimeCount -= Time.deltaTime;


        if (TimeCount <= 0)
        {
            //弾丸を生成

            TimeCount = 5;
            Instantiate(originObject, new Vector3(transform.position.x, transform.position.y, transform.position.z + 2), Quaternion.identity);
        }

        // z軸方向に移動
        
        
        Vector3 force = new Vector3(0, 0, 1) * speed;
        rb.AddForce(force, ForceMode.Impulse);
        

        
      
            

    }
}
