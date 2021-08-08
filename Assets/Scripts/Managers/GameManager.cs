using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // -------------------VARIABLES-------------------
    [Header("UI Elements")]
    public Image playerHealthBar;
    public Image enemyHealthBar;

    public GameObject ButtonPanel;
    public GameObject PauseUI;
    public GameObject PauseButton;

    public TextMeshProUGUI threetwoone;
    public GameObject fightUI;

    public GameObject gameOverUI;
    public TextMeshProUGUI gameOverText;

    [Header("Enemy")]
    public EnemyMovement enemyMove;




    // --------------------SINGLETON------------------
    private static GameManager Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public static GameManager GetInstance()
    {
        return Instance;
    }

    // --------------------SINGLETON------------------


    public void Start()
    {
        PauseUI.SetActive(false);
        threetwoone.gameObject.SetActive(false);
        fightUI.SetActive(false);

        ButtonPanel.SetActive(false);
        PauseButton.SetActive(false);

        StartCoroutine(GameStarter());

    }

    // START THE GAME
    IEnumerator GameStarter()
    {
        // Show 3
        // wait for 0.5 secods
        // Hide 3
        // Wait for 0.5 seconds
        // Show 2....
        threetwoone.gameObject.SetActive(true);
        threetwoone.text = "3";

        yield return new WaitForSeconds(.5f);
        threetwoone.text = "";
        yield return new WaitForSeconds(.5f);
        threetwoone.text = "2";
        yield return new WaitForSeconds(.5f);
        threetwoone.text = "";
        yield return new WaitForSeconds(.5f);
        threetwoone.text = "1";
        yield return new WaitForSeconds(.5f);
        threetwoone.gameObject.SetActive(false);

        yield return new WaitForSeconds(.5f);
        fightUI.SetActive(true);

        yield return new WaitForSeconds(1f);

        fightUI.SetActive(false);

        // START THE GAME FOR REAL!!!
        ButtonPanel.SetActive(true);
        PauseButton.SetActive(true);
        enemyMove.state = EnemyMovement.EnemyState.ALERT;

        // TIMER START

        yield return null;
    }


    // END THE GAME
    public void GameOver(int gameoverMethod)  // 1 - player win , 2 - enemy win, 0 - timeout
    {
        // If the timer hits zero -> Calculate who has done the higher damage and then GO/ KO
        // If the player dies -> Game Over
        // If the enemy dies -> KO

        gameOverUI.SetActive(true);

        switch (gameoverMethod)
        {
            case 0:
                // timeout
                if(enemyHealthBar.fillAmount > playerHealthBar.fillAmount)
                {
                    // enemy win
                    gameOverText.text = "GAME OVER";
                }
                else
                {
                    gameOverText.text = "YOU WIN!!!";
                }

                break;
            case 1:
                // player win
                gameOverText.text = "YOU WIN!!!";
                break;
            case 2:
                //enemy win
                gameOverText.text = "GAME OVER";
                break;
        }

        

    }




    // UPDATE PLAYERS HEALTH
    public void PlayerHealthUIUpdate(float value)
    {
        playerHealthBar.fillAmount = value;
    }

    // UPDATE ENEMY HEALTH
    public void EnemyHealthUIUpdate(float value)
    {
        enemyHealthBar.fillAmount = value;
    }

    // PAUSE AND RESUME
    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseUI.SetActive(true);
        ButtonPanel.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseUI.SetActive(false);
        ButtonPanel.SetActive(true);
    }

}
