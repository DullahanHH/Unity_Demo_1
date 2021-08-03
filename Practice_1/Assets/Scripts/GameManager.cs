using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int min = 01;
    private int sec = 00;

    public GameObject gameOverPanel;
    public GameObject pausePanel;

    private AudioSource backgroundMusic;


    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        backgroundMusic = GetComponent<AudioSource>();

        InvokeRepeating("Counting", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver())
        {
            Invoke("gameOver", 0.25f);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu();
        }

    }

    /**
     * Timmer function
     */
    private void Counting()
    {
        if (sec <= 00)
        {
            if (min <= 00)
            {
                CancelInvoke("Counting");
            } else
            {
                min--;
                sec = 59;
            }
        } else
        {
            sec--;
        }
    }

    public string getMin()
    {
        return string.Format("{0:D2}", min);
    }

    public string getSec()
    {
        return string.Format("{0:D2}", sec);
    }

    public bool isGameOver()
    {
        int playerHealth = FindObjectOfType<Player>().health;
        if (playerHealth <= 0)
        {
            return true;
        }
        return false;
    }


    private void gameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void pauseMenu()
    {
        if (Time.timeScale == 0 && !isGameOver())
        {
            pausePanel.SetActive(false);
            backgroundMusic.Play();
            Time.timeScale = 1;
        } else
        {
            pausePanel.SetActive(true);
            backgroundMusic.Pause();
            Time.timeScale = 0;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
