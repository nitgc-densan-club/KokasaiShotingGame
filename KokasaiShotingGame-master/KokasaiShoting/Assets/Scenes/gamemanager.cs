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
	public GameObject ScoreText;//キャンバスごと有効無効化させるため不必要
	[SerializeField] Text Score, RunningScore;
	[SerializeField] GameObject[] enemyTeams;
	[SerializeField] GameObject[] positionremainder;
	[SerializeField] GameObject ClearWindow;
	[SerializeField] GameObject GameOverWindow;
	int teamNumber;
	GameObject[] numberOfEnemy;
	int NumberOfEnemy;
	public GameObject Sel;

	AudioSource audioSource;
	public AudioClip startSE;
	public AudioClip nextSE;
	public AudioClip otukaresamaSE;

	//result
	List<int> scoreList = new List<int>();
	[SerializeField] Text[] resultRanking_Text = new Text[5];
	[SerializeField] Text myScore_Text, gameOverScoreText;

	// Start is called before the first frame update
	void Start()
	{
		Time.timeScale = 1.0f;
		audioSource = GetComponent<AudioSource>();
		if(GameData.fase == 1) audioSource.PlayOneShot(startSE);
		else audioSource.PlayOneShot(nextSE);
		//フェーズ管理(レベルによって出てくる敵キャラを制限、数値はお任せ)
		for (int i = 0; i < positionremainder.Length; i++)
		{
			if(i % 2 == 0)
				Instantiate(enemyTeams[GameData.fase-1],
				positionremainder[i].transform.position,
				enemyTeams[GameData.fase-1].transform.rotation);
		}

		//クリアチェック用に敵が何体いるか最初に確認し数をintで格納しておく
		numberOfEnemy = GameObject.FindGameObjectsWithTag("Enemy");
		NumberOfEnemy = numberOfEnemy.Length;

		RunningScore.text = "Score: " + GameData.Gamescore + " pts";
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("mainView");
	}

	//別スクリプトから呼び出せるGameOverイベント(演出)アニメーション無し
	public void gameOver()
	{
		//スコア情報更新
		audioSource.PlayOneShot(otukaresamaSE);
		GameOverWindow.SetActive(true);

		//result output
		/*
		myScore_Text.enabled = true;
		myScore_Text.text = GameData.Gamescore.ToString();
		scoreList.Add(GameData.Gamescore);
		scoreList.Sort();
		for(int i = 0; i < Mathf.Min((float)scoreList.Count,(float)5); i++)
		{
			resultRanking_Text[i].text = scoreList[i].ToString();
			resultRanking_Text[i].enabled = true;
		}
		*/

		GameData.fase = 1;
		Time.timeScale = 0f;
		gameOverScoreText.text = "Total Score " + GameData.Gamescore + "pts";
		//GameData.Gamescore = 0;

		Debug.Log("Done Game Over");
	}

	//ボタンに適用する関数
	public void pressedContinue()
	{
		GameData.Life = 4;
		GameData.Gamescore = 0;
		SceneManager.LoadScene("mainView");
	}

	//スタート画面に戻るボタン
	public void ReturnStart()
	{
		GetComponent<StartWindow>().enabled = true;
		SceneManager.LoadScene("StartWindow");
	}

	//次のfaseに向かうボタン
	public void gonextfase()
	{
		GameData.fase++;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	//score増加時の処理
	public void AddScore(int score)
	{
		GameData.Gamescore += score;
	}

	//敵を倒しクリアチェックをする
	public void DeleteAndClearCheck(GameObject Delited)
	{
		NumberOfEnemy--;
		AddScore(10 * GameData.fase);
		RunningScore.text = "Score: " + GameData.Gamescore + " pts";
		if (NumberOfEnemy == 0)
		{
			gonextfase();
		}
		Destroy(Delited);
	}
}