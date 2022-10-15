using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void DiffPlay(int a)
    {
        GameObject.FindWithTag("Player2").GetComponent<Player2>().Difficulty(a);
    }

    public void IsBot()
    {
        GameObject.FindWithTag("Player2").GetComponent<Player2>().IsBot();
    }
}
