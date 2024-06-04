using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject gameOver;
    public GameObject getReady;
    public GameObject playButton;
    public GameObject resetButton;
    public GameObject pause;
    public GameObject pauseText;
    private int score;
    
    private void Awake() {
        gameOver.SetActive(false);
        resetButton.SetActive(false);
        getReady.SetActive(true);
        playButton.SetActive(true);
        pause.SetActive(false);
        pauseText.SetActive(false);
        
        Pause();
    }
    public void Play() {
        getReady.SetActive(false);
        playButton.SetActive(false);
        pause.SetActive(false);
        pauseText.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
    }
    public void Reset() {
        score = 0;
        scoreText.text = score.ToString();
        
        gameOver.SetActive(false);
        resetButton.SetActive(false);
        getReady.SetActive(true);
        playButton.SetActive(true);
        player.ResetPosition();

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void Scoring() {
        score++;
        scoreText.text = score.ToString();
    }
    
    public void GameOver() {
        gameOver.SetActive(true);
        resetButton.SetActive(true);
        
        Pause();
    }

}