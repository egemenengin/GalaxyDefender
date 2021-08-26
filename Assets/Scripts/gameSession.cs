//Egemen Engin
//https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSession : MonoBehaviour
{
    int score = 0;

    private void Awake()
    {
        SetUpSingleton();
    }
    private void SetUpSingleton()
    {
        int numberGameSession = FindObjectsOfType<gameSession>().Length;
        if (numberGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public int GetScore()
    {
        return score;
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
