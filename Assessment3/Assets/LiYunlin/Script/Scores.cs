using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Scores : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public int score=0;
    void Start(){
        SetCountText();
    }
    public void AddScore(int amount)
    {
        this.score += amount; 
        Debug.Log("Score: " + score); 
        SetCountText();
    }
     public void SetCountText()
    {
        countText.text = "Score: " + score.ToString();
    }
}
