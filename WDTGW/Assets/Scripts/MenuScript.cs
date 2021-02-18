using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class MenuScript : MonoBehaviour
{
    public TextMeshProUGUI highScore;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HS").ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Start");
    }

    public void QuitGame()
    {
        Application.Quit();
        ResetHighScore();
        Debug.Log("I quit");
    }

    private void UpdateScore()
    {
        int number = Random.Range(1, 7);
        highScore.text = number.ToString();

        if (number > PlayerPrefs.GetInt("HS", 0))
        {
            PlayerPrefs.SetInt("HS", number);
            highScore.text = number.ToString();
        }
    }

    public void ResetHighScore()
    {  
        PlayerPrefs.DeleteKey("HS");
        highScore.text = "0";
    }

}
