using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public Player1 player1;
    public Player2 player2;
    public Ball ball;
    public GameObject pauseMenu;
    public GameObject optionsMenu;

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameObject.Find("Game").activeSelf)
            {
                if (isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        player1.transform.position = new Vector3(player1.transform.position.x, 0.0f, player1.transform.position.z);
        player2.transform.position = new Vector3(player2.transform.position.x, 0.0f, player2.transform.position.z);
        ball.Restart();
        ball.CurrentTime = 3.0f;
        ball.Score1 = 0;
        ball.Score2 = 0;
        player2.speed = 4.0f;
    }
}
