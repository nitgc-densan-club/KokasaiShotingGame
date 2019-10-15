using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombControl_player : MonoBehaviour
{

    public float deleteTime = 5.0f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, 8, 8, ForceMode.Impulse);
        Destroy(gameObject, deleteTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
