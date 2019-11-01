using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
	Vector3 force;
	Rigidbody rb;
	public int speed = 30;
	public GameObject bullet;
	private float timeElasped = 0;

	// Start is called before the first frame update
	void Start()
	{

		rb = this.GetComponent<Rigidbody>();
		force = new Vector3(0.0f, 0.0f, -1.0f) * speed;

	}

	// Update is called once per frame
	void Update()
	{

		timeElasped += Time.deltaTime;

		if (timeElasped >= 30)
		{
			Destroy(this.gameObject);


			timeElasped = 0.0f;
		}
		rb.AddForce(force, ForceMode.Impulse);
	}




}
