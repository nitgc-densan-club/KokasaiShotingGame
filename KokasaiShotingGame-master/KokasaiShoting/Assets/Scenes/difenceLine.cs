using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difenceLine : MonoBehaviour
{
	GameManager gameManager;
	// Start is called before the first frame update
	void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Enemy")
		{
			Debug.Log(1);
			gameManager.gameOver();
		}
	}
}