using TMPro;
using UnityEngine;

public class PointUi : Singleton<PointUi>
{
    public TextMeshProUGUI OwnText;
    public int score = 0;


    void Start()
    {
        OwnText.text = "SCORE  " + score;
    }

    public void ScoreUpdate(int AddScore)
    {
        score += AddScore;
        OwnText.text = "SCORE  " + score;
    }
    
}
