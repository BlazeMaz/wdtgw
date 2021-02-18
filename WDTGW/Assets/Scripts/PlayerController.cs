using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float maxAV;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public GameObject nextLevelButton;

    private Rigidbody rb;
    private static int score = 0;
    private int currentScore = 0;
    private float time;
    private bool end;
    private int sceneIndex;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxAV;

        scoreText.text = "score: " + score;

        nextLevelButton.SetActive(false);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RestartLevel();
        }

        if (transform.position.y < -2)
        {
            RestartLevel();
        }

        if (!end)
        {
            time += Time.deltaTime;
            timeText.text = "time: " + time.ToString("#.0");
        }
    }

    void FixedUpdate()
    {
        if (!end)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
            rb.AddTorque(movement * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!end)
        {
            if (other.CompareTag("Finish"))
            {
                end = true;
                FindObjectOfType<AudioManager>().Play("win");
                nextLevelButton.SetActive(true);
            }

            if (other.CompareTag("Spikes") || other.CompareTag("Saw"))
            {
                RestartLevel();
            }

            if (other.CompareTag("Coin"))
            {
                score++;
                currentScore++;
                scoreText.text = "score: " + score;

                FindObjectOfType<AudioManager>().Play("pickingCoin");

                Destroy(other.gameObject);
                Debug.Log(score);
            }
        }
    }

    private void RestartLevel()
    {
        score -= currentScore;
        SceneManager.LoadScene(sceneIndex);
    }

    public void NextLevel()
    {
        SetHighScore();
        if (sceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(sceneIndex + 1);
        else
            SceneManager.LoadScene(0);
    }

    private void SetHighScore()
    {
        if (score > PlayerPrefs.GetInt("HS"))
        {
            PlayerPrefs.SetInt("HS", score);
        }
    }
}