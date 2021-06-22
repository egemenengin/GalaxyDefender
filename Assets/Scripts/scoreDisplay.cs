using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scoreDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    gameSession gameSession;
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<gameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameSession.GetScore().ToString();
    }
}
