using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject GameOverText, ScoreText, ContinueButton;
	Text GameOver, Score;
	static int fase = 1;
	public static int Gamescore = 0;
	[SerializeField]
	GameObject[] enemyTeams;
	[SerializeField]
	GameObject[] positionremainder;
	int teamNumber;


	// Start is called before the first frame update
	void Start()
	{
		GameOver = GameOverText.GetComponent<Text>();
		Score = ScoreText.GetComponent<Text>();
		//Invoke("gameOver", 3f);//デバッグ用gameOver起動コード
		/*GameOver.enabled = false;
        ContinueButton.SetActive(false);*/
		int levellimit;
		int randomsighn;
		for (int i = 0; i < positionremainder.Length; i++)
		{
			switch (fase)//出てくる編隊の規制teamNumberの設定
			{
				case 1:
					levellimit = 3;
					break;
				case 2:
					levellimit = 4;
					break;
				default:
					levellimit = positionremainder.Length;
					break;
			}
			randomsighn = Random.Range(0, levellimit + 1);
			Instantiate(enemyTeams[randomsighn], positionremainder[i].transform.position, Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	//別スクリプトから呼び出せるGameOverイベント(演出)アニメーション無し
	public void gameOver()
	{
		int score = 0;//スコア情報更新
		Score.text = "Score " + Gamescore + "pts";
		Score.enabled = true;
		GameOver.enabled = true;//テキスト表示
		ContinueButton.SetActive(true);//(一応)コンティニュー用のボタンを有効に
		GetComponent<GameOverWindow>().enabled = true;

	}

	//ボタンに適用する関数
	public void pressedContinue()
	{
		SceneManager.LoadScene("mainView");
	}

	public void AddScore(int score)
	{
		Gamescore += score;
	}

	public void ReturnStart()
	{
		GetComponent<StartWindow>().enabled = true;
	}
}
