using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public static class GameData
{
	public static int fase = 1;
	public static int Gamescore = 0;
	public static int Life = 4;
}
public class GameManager : MonoBehaviour
{
	public GameObject GameOverText, ScoreText, ContinueButton;
	Text GameOver, Score;
	[SerializeField]
	GameObject[] enemyTeams;
	[SerializeField]
	GameObject[] positionremainder;
	[SerializeField]
	GameObject ClearWindow;
	int teamNumber;
	GameObject[] numberOfEnemy;
	int NumberOfEnemy;


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
			switch (GameData.fase)//出てくる編隊の規制teamNumberの設定
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
		numberOfEnemy = GameObject.FindGameObjectsWithTag("Enemy");
		NumberOfEnemy = numberOfEnemy.Length;
	}

	// Update is called once per frame
	void Update()
	{/*
        numberOfEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (numberOfEnemy.Length == 0)
        {
            gameclear();
        }*/
	}

	//別スクリプトから呼び出せるGameOverイベント(演出)アニメーション無し
	public void gameOver()
	{
		//スコア情報更新
		Score.text = "Score " + GameData.Gamescore + "pts";
		Score.enabled = true;
		GameOver.enabled = true;//テキスト表示
		ContinueButton.SetActive(true);//(一応)コンティニュー用のボタンを有効に
		GetComponent<GameOverWindow>().enabled = true;

	}

	//ボタンに適用する関数
	public void pressedContinue()
	{
		SceneManager.LoadScene("mainView");
		GameData.Gamescore = 0;
	}

	public void AddScore(int score)
	{
		GameData.Gamescore += score;
	}

	public void ReturnStart()
	{
		GetComponent<StartWindow>().enabled = true;
		GameData.Gamescore = 0;
		SceneManager.LoadScene("StartWindow");
	}
	void gameclear()
	{
		ClearWindow.SetActive(true);
	}
	public void gonextfase()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void DeleteAndClearCheck(GameObject Delited)
	{
		NumberOfEnemy--;
		if (NumberOfEnemy == 0)
		{
			gameclear();
		}
		Destroy(Delited);
	}
}