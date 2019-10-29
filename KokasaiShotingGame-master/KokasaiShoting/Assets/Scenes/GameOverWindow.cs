using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverWindow;
    // Start is called before the first frame update
    void Awake()
    {
        gameOverWindow.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            gameOverWindow.SetActive(false);
            Time.timeScale = 1f;
            enabled = false;
        }
    }
}