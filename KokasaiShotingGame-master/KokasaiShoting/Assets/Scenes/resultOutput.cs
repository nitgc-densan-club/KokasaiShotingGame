using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultOutput : MonoBehaviour
{
	public List<playerResult> socreList = new List<playerResult>();
	public int InputScore;
	playerResult pr = new playerResult();
	//Takizawa
	[SerializeField]
	InputField userName;
	// Start is called before the first frame update
	void Start()
	{
		socreList.Add(new playerResult() {playerName="TEST",score=5000});
		GenerateRanking();
	}

	// Update is called once per frame
	void Update()
	{
	}

	void GenerateRanking()
	{
		socreList.Sort((a, b) => b.score - a.score);
		for(int i = 0; i < (int)socreList.Count; i++)
		{
			Debug.Log(socreList[i]);
		}


	}

//takizawa
	void inputusername(){
		userName.text = "";
		//InputField
	}
}

public class playerResult
{
	public int score {get; set;}
	public string playerName {get; set;}
}
