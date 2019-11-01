﻿using System.Collections.Generic;
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
	public GameObject ScoreText/*, GameOverWindow, GameOverText, ContinueButton*/;//キャンバスごと有効無効化させるため不必要
	[SerializeField] Text Score/*, GameOver*/, RunningScore;
	[SerializeField]
	GameObject[] enemyTeams;
	[SerializeField]
	GameObject[] positionremainder;
	[SerializeField]
	GameObject ClearWindow;
	[SerializeField]
	GameObject GameOverWindow;
	int teamNumber;
	GameObject[] numberOfEnemy;
	int NumberOfEnemy;
	public GameObject Sel;

	//フェーズ
	//public int phase_GameManeger;


	// Start is called before the first frame update
	void Start()
	{
		//GameOverWindow.SetActive(false);
		//GameOver = GameOverText.GetComponent<Text>();//Line15に同じ
		//Invoke("gameOver", 3f);//デバッグ用gameOver起動コード
		/*GameOver.enabled = false;
        ContinueButton.SetActive(false);*/

		//フェーズ管理(レベルによって出てくる敵キャラを制限、数値はお任せ)
		//int levellimit;
		for (int i = 0; i < positionremainder.Length; i++)
		{
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
	{/*
        numberOfEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (numberOfEnemy.Length == 0)
        {
            gameclear();
        }*/

		//毎フレーム慚愧の確認をする(もう少しいい方法があったはず・・・)
		if (GameData.Life == 0)
		{
			gameOver();
		}
	}

	//別スクリプトから呼び出せるGameOverイベント(演出)アニメーション無し
	public void gameOver()
	{
		//スコア情報更新
		//Score.text = "Score " + GameData.Gamescore + "pts";
		GameOverWindow.SetActive(true);
		Score.enabled = true;
		GameData.fase = 1;
		Time.timeScale = 0f;
		GameData.Gamescore = 0;
		Debug.Log("Done Game Over");
	}

	//ボタンに適用する関数
	public void pressedContinue()
	{
		SceneManager.LoadScene("mainView");
		//GameData.Gamescore = 0;
	}

	//スタート画面に戻るボタン
	public void ReturnStart()
	{
		GetComponent<StartWindow>().enabled = true;
		SceneManager.LoadScene("StartWindow");
		//GameData.Gamescore = 0;
	}

	//次のfaseに向かうボタン
	public void gonextfase()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		GameData.fase++;
	}

	//score増加時の処理
	public void AddScore(int score)
	{
		GameData.Gamescore += score;
	}

	//faseクリア時[Clear]用のCanvas表示
	void gameclear()
	{
		gonextfase();
		/*
		ClearWindow.SetActive(true);

		Selectable sel = Sel.GetComponent<Selectable> ();
		sel.Select ();*/
	}

	//敵を倒しクリアチェックをする
	public void DeleteAndClearCheck(GameObject Delited)
	{
		NumberOfEnemy--;
		AddScore(10 * GameData.fase);
		RunningScore.text = "Score: " + GameData.Gamescore + " pts";
		if (NumberOfEnemy == 0)
		{
			gameclear();
		}
		Destroy(Delited);
	}
}