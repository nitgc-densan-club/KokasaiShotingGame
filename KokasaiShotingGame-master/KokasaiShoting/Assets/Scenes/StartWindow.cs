﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWindow : MonoBehaviour
{
	[SerializeField]
	GameObject startWindow;
	// Start is called before the first frame update
	void Awake()
	{
		startWindow.SetActive(true);
		Time.timeScale = 0f;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}

		if (Input.anyKey)
		{
			startWindow.SetActive(false);
			Time.timeScale = 1f;
			enabled = false;
		}
	}
}