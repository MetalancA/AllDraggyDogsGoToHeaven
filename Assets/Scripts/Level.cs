using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    [SerializeField] float delayInSeconds = 2f;
    private Vector2 position = new Vector2(180, 180);
    public GameObject waveText;
    public int score;


    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GamePlay");
        MakeText();
        Debug.Log("The game has been loaded.");
        Time.timeScale = 1;
        score = 0;
        

    }

    public void LoadLevelUp()
    {
        
        SceneManager.LoadScene("Highscores");
	//CloudOnceServices.instance.SubmitScoreToLeaderboard(FindObjectOfType<GameSession>().GetScore());
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadPrivacyPolicy()
    {
        SceneManager.LoadScene("Privacy Policy");
    }

    public void LoadEnterUsername()
    {
       
        SceneManager.LoadScene("Highscores");
	//CloudOnceServices.instance.SubmitScoreToLeaderboard(FindObjectOfType<GameSession>().GetScore());

    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
        
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MakeText()
    {

        GameObject wave = GameObject.Instantiate(waveText, transform.position, transform.rotation) as GameObject;
  

    }



}
