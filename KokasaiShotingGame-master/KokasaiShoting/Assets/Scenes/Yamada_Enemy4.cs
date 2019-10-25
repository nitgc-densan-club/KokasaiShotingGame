using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Yamada_Enemy4 : MonoBehaviour
{
	int Speed = 1;
	Rigidbody rb;
	Vector3 nextVec;
	private float timeElasped = 0;
	int rnd;
	public GameObject bullet;
	// Use this for initialization
	void Start()
	{
		rb = this.GetComponent<Rigidbody>();
		nextVec = new Vector3(0.0f, 0.0f, 1.0f) * Speed;
	}
	// Update is called once per frame
	void Update()
	{
		timeElasped += Time.deltaTime;
		if (timeElasped >= 2)
		{
			// 乱数の範囲指定で配列のインデックスを取得する
			rnd = Random.Range(0, 5);
			switch (rnd)
			{
				case 0:
					// transform.Translate(new Vector3(10, 0, 1/2) * Time.deltaTime * Speed);
					nextVec.x = 10;
					nextVec.y = 0;
					nextVec.z = 1 / 2;
					break;
				case 1:
					//transform.Translate(new Vector3(-10, 0, 1/2) * Time.deltaTime * Speed);
					nextVec.x = -10;
					nextVec.y = 0;
					nextVec.z = 1 / 2;
					break;
				case 2:
					//transform.Translate(new Vector3(0, 10, 1/2) * Time.deltaTime * Speed);
					nextVec.x = 0;
					nextVec.y = 0;
					nextVec.z = 1 / 2;
					break;
				case 3:
					//transform.Translate(new Vector3(0, -10, 1/2) * Time.deltaTime * Speed);
					nextVec.x = 0;
					nextVec.y = -10;
					nextVec.z = 1 / 2;
					break;
				case 4:
					//transform.Translate(new Vector3(10, 10, 1/2) * Time.deltaTime * Speed);
					nextVec.x = 10;
					nextVec.y = 10;
					nextVec.z = 1 / 2;
					break;
				case 5:
					// transform.Translate(new Vector3(-10, -10, 1/2) * Time.deltaTime * Speed);
					nextVec.x = -10;
					nextVec.y = -10;
					nextVec.z = 1 / 2;
					break;
			}
			timeElasped = 0.0f;
		}
		if (timeElasped >= 5)
		{
			Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), bullet.transform.rotation);
			timeElasped = 0.0f;
		}
		rb.AddForce(nextVec * Speed, ForceMode.Impulse);
	}
}