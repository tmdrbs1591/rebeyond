using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int p1Score = 0;
    public int p2Score = 0;
    private int endP1Score = 0;
    private int endP2Score = 0;
    
    public TMP_Text player1ScoreText;
    public TMP_Text player2ScoreText;

    void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        Player1Score();
        Player2Score();
    }

    public void Player1ScoreUp()
    {
        p1Score += 100;
    }
    
    public void Player2ScoreUp()
    {
        p2Score+= 100;
    }
    
    public void Player1Score()
    {
        player1ScoreText.text = "Player1Score: " + p1Score.ToString();
    }

    public void Player2Score()
    {
        player2ScoreText.text = "Player2Score: " + p2Score.ToString();
    }

    public void EndingPlayer1Score()
    {
        endP1Score = p1Score; 
    }

    public void EndingPlayer2Score()
    {
        endP2Score = p2Score; 
    }
}
