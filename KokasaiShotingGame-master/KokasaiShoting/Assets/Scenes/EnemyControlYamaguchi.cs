using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlYamaguchi : MonoBehaviour
{

	float bulTimer = 5;
	float zigTimer = 4;
	int counter = 0;
	public GameObject originObject;
	Rigidbody rb;
	Vector3 force;
	public float speed = 0.1f;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		// z軸方向に移動
		force = new Vector3(1, 0, -1);
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
					rb.velocity = new Vector3(0, 0, 0);
					force = new Vector3(-1.5f, 0, -1);
					break;
				case 2:
					rb.velocity = new Vector3(0, 0, 0);
					force = new Vector3(1, 0, -1.5f);
					counter = 0;
					break;
			}
			zigTimer = 4;
		}

		rb.AddForce(force * speed, ForceMode.Impulse);

	}
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "PlayerBullet")
		{
			Debug.Log(1);
			Destroy(this.gameObject);
		}
	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "PlayerBomb")
		{
			Destroy(this.gameObject);
		}
	}

}
