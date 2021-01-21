using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManger : MonoBehaviour
{

    public GameObject restartMenuUI;

    bool gameHasEnded = false;
    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Time.timeScale = 0f;
            restartMenuUI.SetActive(true);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
