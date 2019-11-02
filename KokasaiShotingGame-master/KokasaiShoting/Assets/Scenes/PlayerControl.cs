using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

	GameManager gameManager;
	public GameObject ball;
	public GameObject bomb;
	public GameObject guard;
	public float speed = 1.0f;
	public Rigidbody rb;
	int rimit = 5;
	bool shotflag = true;
	bool bombflag = true;
	bool guardflag = true;
	GameObject guardclone = null;
	public AudioClip ShotBulletSE;
	public AudioClip DamageSE;
	AudioSource audioSource;

	bool flag_muteki = true;

	[SerializeField]
	Text LifeText;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
		gameManager = FindObjectOfType<GameManager>();
		LifeText.text = GameData.Life.ToString();
	}

	// Update is called once per frame
	void Update()
	{
		//バレット
		if (Input.GetButton("Shot") && shotflag)
		{
			audioSource.PlayOneShot(ShotBulletSE);
			Instantiate(ball, new Vector3(transform.position.x, transform.position.y, 10), ball.transform.rotation);
			shotflag = false;
			StartCoroutine(EffectTimer(0.2f, "shot"));
		}
		//ボム
		if (Input.GetButtonDown("Bomb") && rimit > 0 && bombflag)
		{
			Instantiate(bomb, new Vector3(transform.position.x, 10, 10), bomb.transform.rotation);
			rimit--;
			bombflag = false;
			StartCoroutine(EffectTimer(2.0f, "bomb"));
		}
		//移動
		float x = Input.GetAxisRaw("Horizontal") * speed;
		float y = Input.GetAxisRaw("Vertical") * speed;

		rb.AddForce(x, y, 0, ForceMode.Impulse);

		//ガード
		if (Input.GetButtonDown("Guard") && guardflag == true)
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

		if(!flag_muteki)
		{
			flag_muteki = true;
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
		if (collision.gameObject.tag == "EnemyBullet")
		{
			audioSource.PlayOneShot(DamageSE);
			Debug.Log("damege!!");
			GameData.Life -= 1;
			LifeText.text = GameData.Life.ToString();
			if (GameData.Life <= 0)
			{
				gameManager.gameOver();
			}
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "item")
		{
			//Debug.Log("1" + speed);
			speed = speed * 2;
			//Debug.Log("2" + speed);
			Destroy(collider.gameObject);
			StartCoroutine(EffectTimer(30.0f, "speed"));
		}
		if (collider.gameObject.tag == "EnemyBullet" && flag_muteki)
		{
			Destroy(collider.gameObject);
			flag_muteki = false;
			GameData.Life -= 1;
			LifeText.text = GameData.Life.ToString();
			if (GameData.Life <= 0)
			{
				gameManager.gameOver();
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
			case "shot":
				shotflag = true;
				break;
			case "bomb":
				bombflag = true;
				break;
			case "guard":
				guardflag = true;
				break;
		}
	}
}