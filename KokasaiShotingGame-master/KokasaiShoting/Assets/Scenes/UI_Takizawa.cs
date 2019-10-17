using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject GameOverText, ContinueButton;
	Text GameOver;

	// Start is called before the first frame update
	void Start()
	{
		GameOver = GameOverText.GetComponent<Text>();
		/*GameOver.enabled = false;
        ContinueButton.SetActive(false);*/
	}

	// Update is called once per frame
	void Update()
	{

	}

	//別スクリプトから呼び出せるGameOverイベント(演出)アニメーション無し
	public void gameOver()
	{
		GameOver.enabled = true;//テキスト表示
		ContinueButton.SetActive(true);//(一応)コンティニュー用のボタンを有効に
	}

	//Continue(初めから)ボタンに適用する関数
	public void pressedContinue()
	{
		SceneManager.LoadScene("mainView");
	}
}