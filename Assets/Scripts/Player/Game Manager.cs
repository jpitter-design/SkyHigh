using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager: MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI TitleText;
    public Image BackGround;
    public bool IsGameActive = false;
    public Button restartButton;
    public Button StartG;
    public Button HowToPlay;
    public Button Back;
    public PlayerController Player;
   
    public Transform playerTransform;


    private double scoreTimer;
    private int score;
    void Start()
    {
        score = 0;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
    }

    void Update()
    {
        UpdateScore();

    }
    private void UpdateScore()
    {
        if(IsGameActive == true){
            scoreTimer += Time.deltaTime;
            if (scoreTimer >= 1.0f)
            {
                score += 1;
                scoreTimer = 0;
                scoreText.text = "Score: " + score;
            }
        }


    }
    public void GameOver()
    {
            GameOverText.gameObject.SetActive(true);
            IsGameActive = false;

    }
    
    public void StartGame()
    {
        IsGameActive = true;
        TitleText.gameObject.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Rules()
    {
        BackGround.gameObject.SetActive(true);
    }
    public void back()
    {
        BackGround.gameObject.SetActive(false);

    }
}
