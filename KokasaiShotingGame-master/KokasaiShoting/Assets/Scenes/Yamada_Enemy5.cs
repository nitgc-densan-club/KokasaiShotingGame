using UnityEngine;
using System.Collections;
public class Yamada_Enemy5 : MonoBehaviour
{
	Vector3 force;
	private float speed;
	public int Speed = -3;
	private float radius;
	private float yPosition;
	public Rigidbody rbody;
	public GameObject bullet;
	private float timeElasped;
	// Use this for initialization
	void Start()
	{
		speed = 5.0f;
		radius = 20.0f;
		yPosition = 3.5f;
		rbody = this.GetComponent<Rigidbody>();
		force = new Vector3(0.0f, 0.0f, 1.0f) * Speed;
	}
	// Update is called once per frame
	void Update()
	{
		rbody.MovePosition(
			new Vector3(
				radius * Mathf.Sin(Time.time * speed),
				yPosition,
				radius * Mathf.Cos(Time.time * speed)
			)
		);
		timeElasped += Time.deltaTime;
		if (timeElasped >= 5)
		{
			Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), bullet.transform.rotation);
			timeElasped = 0.0f;
		}
		rbody.AddForce(force, ForceMode.Impulse);
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