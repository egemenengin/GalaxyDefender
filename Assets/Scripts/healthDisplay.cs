//Egemen Engin
//https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class healthDisplay : MonoBehaviour
{
    TextMeshProUGUI healthText;
    Player player1 ;
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        player1 = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = player1.getHealth().ToString();
    }
}
