using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unagi_move : MonoBehaviour
{

	float speed = -3.0f;
	float delta = 0;
	int counter = 0;

	public GameObject tama;//tamaのオブジェクトを干渉
	Rigidbody rb;
	Vector3 nextVec = new Vector3(0, 0, -1); //次の進行方向
	Vector3 mypos = new Vector3();//自身の座標をmyposとする

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{   //このスクリプトがついているオブジェクト（main）の座標
		mypos = this.transform.position;

		//時間経過［ｓ］とともに値を増加
		delta += Time.deltaTime;
		//３秒たつごとに動きを切り替える
		if (delta >= 3)
		{
			//countの値を増加させる
			counter++;

			switch (counter)
			{
				case 1:

					//オブジェクトにかかっている力を初期化
					rb.velocity = new Vector3(0, 0, 0);

					//次の進行方向を指定
					//ｚ方向に進む
					nextVec = new Vector3(0, 0, 1);

					// tamaを発射
					Instantiate(tama, new Vector3(mypos.x, mypos.y, mypos.z - 1), tama.transform.rotation);

					break;

				case 2:

					rb.velocity = new Vector3(0, 0, 0);

					//ｚ方向に進行しつつｚの２倍の速度でｘ方向に進む
					nextVec = new Vector3(2, 0, 1);

					break;

				case 3:

					rb.velocity = new Vector3(0, 0, 0);

					//z方向に進行しつつｚの２倍の速度で-x方向に進む
					nextVec = new Vector3(-2, 0, 1);

					//counterをリセット
					counter = 0;

					break;

			}
			//deltatimeをリセット
			delta = 0;

			//上記の進行方向にspeedの速度で力を加える
			rb.AddForce(nextVec * speed, ForceMode.Impulse);
		}


		//z座標が0になったら自身（main）を破壊
		if (mypos.z <= 0)
		{
			Destroy(this.gameObject);
		}
	}

	//衝突判定
    private void OnCollisionEnter(Collision collision)
	{
		//PlayerBulletに当たったら自身を破壊
		if (collision.gameObject.tag == "PlayerBullet")
		{
			Destroy(this.gameObject);
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PlayerBom")
		{
			Destroy(this.gameObject);
		}
	}
}