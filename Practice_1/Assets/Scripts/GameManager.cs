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

        GetComponent<BoxCollider2D>().enabled = false;      //disable the trigger when start
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
                BossEvent();
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

    /**
     * Destroy all the enemy, start boss event
     */
    private void BossEvent()
    {
        FindObjectOfType<EnemyGenerator>().CancelInvoke("Generator");       //stop generating enemies
        GetComponent<BoxCollider2D>().enabled = true;       //set trigger active to clean the screen
    }

    /**
     * Kill every enemy in the trigger
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().health = 0;
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
