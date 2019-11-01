using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public GameObject ball;
	public GameObject bomb;
	public GameObject guard;
	public float speed = 1.0f;
	public Rigidbody rb;
	int life = 4;
	int rimit = 5;
	bool guardflag = true;
	GameObject guardclone = null;
	public AudioClip Player_ShotBulletSE;
	AudioSource audioSource;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		//バレット
		if (Input.GetKeyDown(KeyCode.Space))
		{
			audioSource.PlayOneShot(Player_ShotBulletSE);
			Instantiate(ball, new Vector3(transform.position.x, transform.position.y, 10), ball.transform.rotation);
		}
		//ボム
		if (Input.GetKeyDown(KeyCode.B))
		{
			if (rimit > 0)
			{
				Instantiate(bomb, new Vector3(transform.position.x, 10, 10), bomb.transform.rotation);
				rimit--;
			}
		}
		//移動
		float x = Input.GetAxisRaw("Horizontal") * speed;
		float y = Input.GetAxisRaw("Vertical") * speed;

		rb.AddForce(x, y, 0, ForceMode.Impulse);

		//ガード
		if (Input.GetKeyDown(KeyCode.V) && guardflag == true)
		{
			if (guardclone != null) Destroy(guardclone);
			guardclone = Instantiate(guard, new Vector3(transform.position.x, transform.position.y, 10), guard.transform.rotation);
			guardflag = false;
			StartCoroutine(EffectTimer(2.0f, "guard"));
		}

		//キーが離されたときに慣性を消去
		if (Input.GetKeyUp(KeyCode.UpArrow))
		{
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}

		if (Input.GetKeyUp(KeyCode.DownArrow))
		{
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}

		if (Input.GetKeyUp(KeyCode.RightArrow))
		{
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}

		if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}

		if (Input.GetKeyUp(KeyCode.W))
		{
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}

		if (Input.GetKeyUp(KeyCode.A))
		{
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}

		if (Input.GetKeyUp(KeyCode.S))
		{
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}

		if (Input.GetKeyUp(KeyCode.D))
		{
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
		//移動制御
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


	}

	//アイテム
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "item")
		{
			//Debug.Log("1" + speed);
			speed = speed * 2;
			//Debug.Log("2" + speed);
			Destroy(collision.gameObject);
			StartCoroutine(EffectTimer(30.0f, "speed"));
		}
		if (collision.gameObject.tag == "EnamyBullet")
		{
			life = life - 1;
			if (life == 0)
			{
				Destroy(this.gameObject);
			}
		}
	}

	//コルーチンの本体
	IEnumerator EffectTimer(float time, string events)
	{
		yield return new WaitForSeconds(time);
		switch (events)
		{
			case "speed":
				speed = speed / 2;
				break;
			case "guard":
				guardflag = true;
				break;
		}
	}
}