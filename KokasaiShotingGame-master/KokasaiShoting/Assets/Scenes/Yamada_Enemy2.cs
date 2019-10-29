using UnityEngine;
using System.Collections;
public class Yamada_Enemy2 : MonoBehaviour
{
	int a;
	Rigidbody rb;
	Vector3 nextVec;
	public int speed = 3;
	public GameObject bullet;
	private float timeElasped;
	void Start()
	{
		rb = this.GetComponent<Rigidbody>();
		nextVec = new Vector3(0.0f, 0.0f, 1.0f) * speed;
	}
	// Update is called once per frame
	void Update()
	{
		a = (int)(Time.time % 2);
		if (a == 0)
		{
			rb.velocity = new Vector3(0, 0, 0);
			nextVec = new Vector3(3, 0, 3);
		}
		else
		{
			rb.velocity = new Vector3(0, 0, 0);
			nextVec = new Vector3(-3, 0, 3);
		}
		timeElasped += Time.deltaTime;
		if (timeElasped >= 5)
		{
			Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), bullet.transform.rotation);
			timeElasped = 0.0f;
		}
		rb.AddForce(nextVec * speed, ForceMode.Impulse);
	}
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "PlayerBullet")
		{
			Destroy(gameObject);
		}
		else
		{
			//それ以外の処理
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PlayerBomb")
		{
			Destroy(gameObject);
		}
		else
		{
		}
	}
}