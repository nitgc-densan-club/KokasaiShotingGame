using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletYamaguchi : MonoBehaviour
{

	Rigidbody rb;
	Vector3 force;
	public int speed = 3;
	float TimeCount = 30;
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		force = new Vector3(0, 0, 1) * speed;
	}

	// Update is called once per frame
	void Update()
	{

		TimeCount -= Time.deltaTime;

		if (TimeCount <= 0)
		{
			//自身を破壊
			Destroy(this.gameObject);
		}

		rb.AddForce(force, ForceMode.Impulse);
	}
}
