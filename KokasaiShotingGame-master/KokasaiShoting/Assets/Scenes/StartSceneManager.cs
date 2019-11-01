using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
	//ゲームスタートボタン
	public void PressedStart()
	{
		SceneManager.LoadScene("mainView");
	}

	//ゲームをやめるボタン
	public void PressedQuit()
	{
		Application.Quit();
	}
		void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			//Application.Quit();
			//SceneManager.LoadScene("StartWindow");
			Application.Quit();
		}

		if (Input.anyKey)
		{
			PressedStart();
		}
	}
}