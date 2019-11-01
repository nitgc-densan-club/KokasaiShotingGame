using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class YamadaEnemy : MonoBehaviour
{
	public GameObject bullet;
	private float timeElasped;
	public float speed = -0.01f;
	Vector3 force;
	Rigidbody rb;
	GameManager game;
	void Start()
	{
		rb = this.GetComponent<Rigidbody>();
		force = new Vector3(0.0f, 0.0f, 1.0f);
		game = FindObjectOfType<GameManager>();
	}
	// Update is called once per frame
	void Update()
	{
		timeElasped += Time.deltaTime;
		if (timeElasped >= 6)
		{
			Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), bullet.transform.rotation);
			timeElasped = 0.0f;
		}
		rb.AddForce(force * speed, ForceMode.Impulse);
	}
	/*
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
	*/
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PlayerBomb")
		{
			//Destroy(gameObject);
			game.DeleteAndClearCheck(this.gameObject);
		}
		if (other.gameObject.tag == "PlayerBullet")
		{
			//Destroy(gameObject);
			game.DeleteAndClearCheck(this.gameObject);
		}
	}
}