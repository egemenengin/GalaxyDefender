//Egemen Engin
//https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level : MonoBehaviour
{
    [SerializeField] float delaySeconds = 2f;
    public void loadNextScene()
    {
        int curSceneInd = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curSceneInd+1);
    }
    public void loadMainMenu()
    {

        SceneManager.LoadScene("MainMenu");
    }
    public void loadGame()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<gameSession>().ResetGame();
    }
    public void loadSettingsScene()
    {

        SceneManager.LoadScene("Settings");
    }
    public void loadGameOverScene()
    {

        StartCoroutine(loadDelay());
    }
    IEnumerator loadDelay()
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene("GameOver");
    }


    public void quitGame()
    {
        Application.Quit();
    }
}
