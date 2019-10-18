using UnityEngine;
using System.Collections;
public class Yamada_Enemy2 : MonoBehaviour
{
	int a;
	Rigidbody rb;
	Vector3 force;
	public int speed = 1;
	public int Speed = 10;
	public GameObject bullet;
	private float timeElasped;
	void Start()
	{
		rb = this.GetComponent<Rigidbody>();
		force = new Vector3(0.0f, 0.0f, 1.0f) * speed;
	}
	// Update is called once per frame
	void Update()
	{
		a = (int)(Time.time % 2);
		if (a == 0)
			transform.Translate(new Vector3(1, 0, 1) * Time.deltaTime * Speed);
		else
			transform.Translate(new Vector3(-1, 0, 1) * Time.deltaTime * Speed);
		timeElasped += Time.deltaTime;
		if (timeElasped >= 5)
		{
			Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), bullet.transform.rotation);
			timeElasped = 2.0f;
			rb.AddForce(force, ForceMode.Impulse);
		}
	}
}