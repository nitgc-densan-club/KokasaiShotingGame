using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Yamda_Enemy6 : MonoBehaviour
{
	Vector3 force;
	private float speed;
	public int Speed = -100;
	private float radius;
	private float yPosition;
	public Rigidbody rbody;
	public GameObject bullet;
	private float timeElasped;
	GameManager game;
	// Use this for initialization
	void Start()
	{
		speed = 5.0f;
		radius = 50.0f;
		yPosition = 3.5f;
		rbody = this.GetComponent<Rigidbody>();
		force = new Vector3(0.0f, 0.0f, 1.0f) * Speed;
		game = FindObjectOfType<GameManager>();
	}
	// Update is called once per frame
	void Update()
	{
		rbody.MovePosition(
			new Vector3(
				radius * Mathf.Sin(Time.time * speed),
				yPosition,
				radius * Mathf.Sin(Time.time * speed)
			 )
		);
		timeElasped += Time.deltaTime;
		if (timeElasped >= 5)
		{
			Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), bullet.transform.rotation);
			timeElasped = 0.0f;
		}
		if (transform.position.x >= 60)
		{
			rbody.velocity = Vector3.zero;
			transform.position = new Vector3(59.9f, transform.position.y, transform.position.z);
		}
		if (transform.position.x >= -60)
		{
			rbody.velocity = Vector3.zero;
			transform.position = new Vector3(-59.9f, transform.position.y, transform.position.z);
		}
		if (transform.position.y >= 30)
		{
			rbody.velocity = Vector3.zero;
			transform.position = new Vector3(transform.position.x, 29.9f, transform.position.z);
		}
		if (transform.position.y >= -30)
		{
			rbody.velocity = Vector3.zero;
			transform.position = new Vector3(transform.position.x, -29.9f, transform.position.z);
		}
		rbody.AddForce(force, ForceMode.Impulse);
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
			game.DeleteAndClearCheck(this.gameObject);
		}
		if (other.gameObject.tag == "PlayerBullet")
		{
			game.DeleteAndClearCheck(this.gameObject);
		}
	}
}