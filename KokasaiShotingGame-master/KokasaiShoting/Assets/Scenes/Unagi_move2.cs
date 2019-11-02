using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unagi_move2 : MonoBehaviour
{

	public float speed = -3.0f;
	float distance_two;
	float delta;
	public GameObject tama;

	Vector3 start = new Vector3(1, 1, 65);
	Vector3 end = new Vector3(1, 1, 0);
	Vector3 control = new Vector3(1, 1, 32.5f) + Vector3.up * 10;
	Vector3 mypos = new Vector3();
	GameManager game;

	// Use this for initialization
	void Start()
	{
		distance_two = Vector3.Distance(start, end);
		game = FindObjectOfType<GameManager>();
	}

	// Update is called once per frame
	void Update()
	{

		delta += Time.deltaTime;
		//３秒たつごとに動きを切り替える
		if (delta >= 3)
		{
			//countの値を増加させる
			Instantiate(tama, new Vector3(mypos.x, mypos.y, mypos.z - 1), tama.transform.rotation);
			delta = 0;
		}
		//現在の位置情報を取得
		float present_Location = (Time.time * speed) / distance_two;
		//座標変更
		transform.position = Sample(start, end, control, present_Location);


	}

	Vector3 Sample(Vector3 start, Vector3 end, Vector3 control, float t)
	//tはstertからendまでの距離を１としたときの経過距離
	{
		//controlからstertまでの軌道
		Vector3 Q0 = Vector3.Lerp(start, control, t);

		//endからcontrolまでの軌道
		Vector3 Q1 = Vector3.Lerp(control, end, t);

		//座標Q1からQ0の軌道
		Vector3 Q2 = Vector3.Lerp(Q0, Q1, t);

		return Q2;//Q2はその時のカーブ地点

	}

	//衝突判定
	/*
	private void OnCollisionEnter(Collision collision)
	{
		//PlayerBulletに当たったら自身を破壊
		if (collision.gameObject.tag == "PlayerBullet")
		{
			Destroy(this.gameObject);
		}
	}
	*/
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PlayerBom")
		{
			game.DeleteAndClearCheck(this.gameObject);
		}
		if (other.gameObject.tag == "PlayerBullet")
		{
			game.DeleteAndClearCheck(this.gameObject);
		}
	}
}