using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Handler : MonoBehaviour
{
    private float Wait = 5f;

    public Text gameOverText;
    public Text YouWinText;

    private bool gameOver;
    private bool Win;

    void Start()
    {
        gameOver = false;
        gameOverText.text = "";
        Win = false;
        YouWinText.text = "";
    }
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            
            GameOver();

            if (Wait <= 0)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                Wait -= Time.deltaTime;
            }
        }

        if (GameObject.FindGameObjectWithTag("YouWin"))
        {
            YouWin();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Application.Quit();
        }
    }
    public void GameOver()
    {
        
        gameOver = true;
        gameOverText.text = "Game Over";
    }
    public void YouWin()
    {
        Win = true;
        YouWinText.text = "You Win";
    }
}
