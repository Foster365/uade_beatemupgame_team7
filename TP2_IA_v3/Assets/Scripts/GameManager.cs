using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Player _player;
    private EnemyBoss _boss;
    private TimerCountdown _timer;
    public GameObject youWinUI;
    public GameObject timeOutUI;
    public GameObject youDiedUI;
    public GameObject backToMenu;

    void Awake()
    {
        _player = FindObjectOfType<Player>();
        _boss = FindObjectOfType<EnemyBoss>();
        _timer = FindObjectOfType<TimerCountdown>();
    }

    private void Update()
    {
        if (_player.isDead)
        {
            youDiedUI.SetActive(true);
            backToMenu.SetActive(true);
        }
        else if (_timer.secondsLeft <= 0)
        {
            timeOutUI.SetActive(true);
            backToMenu.SetActive(true);
        }
        else if (_boss.isDead)
        {
            youWinUI.SetActive(true);
            backToMenu.SetActive(true);
        }

        
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
