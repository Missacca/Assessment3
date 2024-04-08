using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Scores : MonoBehaviour
{
    public TextMeshProUGUI countText;
     public TextMeshProUGUI countText2;
    public int score=0;
    public int other=7;
    void Start(){
        SetCountText();
    }
    public void AddScore(int amount)
    {
        this.score += amount; 
        other=7-score;
        Debug.Log("Score: " + score); 
        SetCountText();
    }
     public void SetCountText()
    {
        countText.text = "Score: " + score.ToString();
        countText2.text = "You also need Kill: " + other.ToString()+"  enemy to win!!";
    }
}
