using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{
    private void Awake()
    {
        setUpSingleton();
    }

    private void setUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length>1)
        {
            Destroy(gameObject);
        }
         else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
  
}
