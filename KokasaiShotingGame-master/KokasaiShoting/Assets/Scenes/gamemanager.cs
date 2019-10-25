using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
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
        int levellimit;
        int randomsighn;
        for (int i = 0; i < positionremainder.Length; i++) {
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

    public void AddScore(int score)
    {
        Gamescore += score;
    }
}
