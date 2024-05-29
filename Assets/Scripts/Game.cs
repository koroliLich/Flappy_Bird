using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Player player;
    public Text scoretext;
    public GameObject gameOver;
    public GameObject getReady;
    public GameObject playButton;
    public GameObject resetButton;
    private int score;

    private void Awake() {
        gameOver.SetActive(false);
        resetButton.SetActive(false);
        getReady.SetActive(true);
        playButton.SetActive(true);
        
        Pause();
    }
    private void OnEnable() {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
    }
    public void Play() {
        getReady.SetActive(false);
        playButton.SetActive(false);
        
        Time.timeScale = 1f;
        player.enabled = true;
    }
    public void Reset() {
        score = 0;
        scoretext.text = score.ToString();
        
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
        scoretext.text = score.ToString();
    }
    
    public void GameOver() {
        gameOver.SetActive(true);
        resetButton.SetActive(true);
        
        Pause();
    }

}