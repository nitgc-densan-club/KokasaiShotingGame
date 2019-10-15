using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject ball;
    public GameObject bomb;
    public float speed = 10.0f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(-0.5f, 0, 0);
        }
        //if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(0.5f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(ball, new Vector3(transform.position.x, transform.position.y, transform.position.z), ball.transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Instantiate(bomb, new Vector3(transform.position.x, transform.position.y, transform.position.z), bomb.transform.rotation);
        }
        float x = Input.GetAxisRaw("Horizontal") * speed;
        
        rb.AddForce(x, 0, 0);
    }
}
