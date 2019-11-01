using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Yamaguchi_ThirdEnemy : MonoBehaviour
{
	float bulTimer = 5;
	float zigTimer = 2;
	int counter = 0;
	public GameObject originObject;
	Rigidbody rb;
	Vector3 force;
	public float speed = -0.1f;
	GameManager game;
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		// z軸方向に移動
		force = new Vector3(1, 0, 1);
		game = FindObjectOfType<GameManager>();
	}
	// Update is called once per frame
	void Update()
	{
		bulTimer -= Time.deltaTime;
		if (bulTimer <= 0)
		{
			//弾丸を生成
			Instantiate(originObject, new Vector3(transform.position.x, transform.position.y, transform.position.z + 2), transform.rotation);
			bulTimer = 5;
		}
		//ジグザグに移動
		zigTimer -= Time.deltaTime;
		if (zigTimer <= 0)
		{
			counter++;
			switch (counter)
			{
				case 1:
					//オブジェクトにかかっている力を初期化
					//rb.velocity = new Vector3(0, 0, 0);
					force = new Vector3(-0.5f, 0, 1);
					break;
				case 2:
					//オブジェクトにかかっている力を初期化
					//rb.velocity = new Vector3(0, 0, 0);
					// force = new Vector3(0.7f, 0, -0.7f);
					break;
				case 3:
					//rb.velocity = new Vector3(0, 0, 0);
					force = new Vector3(1, 0, 1);
					break;
				case 4:
					//rb.velocity = new Vector3(0, 0, 0);
					//force = new Vector3(-0.7f, 0, -0.7f);
					counter = 0;
					break;
			}
			zigTimer = 4;
		}
		if (transform.position.x >= 60)
		{
			rb.velocity = Vector3.zero;
			transform.position = new Vector3(59.9f, transform.position.y, transform.position.z);
		}
		if (transform.position.x <= -60)
		{
			rb.velocity = Vector3.zero;
			transform.position = new Vector3(-59.9f, transform.position.y, transform.position.z);
		}
		if (transform.position.y >= 30)
		{
			rb.velocity = Vector3.zero;
			transform.position = new Vector3(transform.position.x, 29.9f, transform.position.z);
		}
		if (transform.position.y <= -30)
		{
			rb.velocity = Vector3.zero;
			transform.position = new Vector3(transform.position.x, -29.9f, transform.position.z);
		}
		rb.AddForce(force * speed, ForceMode.Impulse);
	}
	/*
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "PlayerBullet")
		{
			Destroy(this.gameObject);
		}
	}
	 */
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PlayerBomb")
		{
			game.DeleteAndClearCheck(this.gameObject);
		}
		if (other.gameObject.tag == "PlayerBullet")
		{
			game.DeleteAndClearCheck(this.gameObject);
		}
	}
}