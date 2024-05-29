using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Player player;
    public Text scoretext;
    private int score;

    public void Scoring() {
        score++;
        scoretext.text = score.ToString();
    }
    
    public void GameOver() {
        Time.timeScale = 0f;
        player.enabled = false;
    }

}