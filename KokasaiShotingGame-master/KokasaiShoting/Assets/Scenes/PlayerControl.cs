using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public GameObject ball;
	public GameObject bomb;
	public GameObject guard;
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
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Instantiate(ball, new Vector3(transform.position.x, transform.position.y, 10), ball.transform.rotation);
		}
		if (Input.GetKeyDown(KeyCode.B))
		{
			Instantiate(bomb, new Vector3(transform.position.x, 10, 10), bomb.transform.rotation);
		}
		float x = Input.GetAxisRaw("Horizontal") * speed;
		float y = Input.GetAxisRaw("Vertical") * speed;

        rb.AddForce(x, y, 0);

        //ガード
        if (Input.GetKeyDown(KeyCode.V))
		{
			Instantiate(guard, new Vector3(transform.position.x, transform.position.y, 10), guard.transform.rotation);
		}
	}

    //アイテム
    private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "item")
		{
			//Debug.Log("1" + speed);
			speed = speed * 2;
			//Debug.Log("2" + speed);
			Destroy(collision.gameObject);
			StartCoroutine("EffectTimer", 30.0f);
		}
	}

	//コルーチンの本体
	IEnumerator EffectTimer(float time)
	{
		yield return new WaitForSeconds(time);
		speed = speed / 2;
		//Debug.Log("3" + speed);
	}
}