using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Scores : MonoBehaviour
{
    public TextMeshProUGUI countText;
     public TextMeshProUGUI countText2;
    public int score=0;
    public GameObject NextPanel;
    public int other=7;
    public AudioSource wina;
    void Start(){
        SetCountText();
         if (NextPanel != null)
        {
            NextPanel.SetActive(false);
        }
    }
    public void AddScore(int amount)
    {
        this.score += amount; 
        other=7-score;
        Debug.Log("Score: " + score); 
        SetCountText();
        Invoke("gameWin",2f);
    }
     public void SetCountText()
    {
        countText.text = "Score: " + score.ToString();
        countText2.text = "You also need Kill: " + other.ToString()+"  enemy to win!!";
    }
    public void gameWin()
    {
        if(score==7){
            wina.Play();
             gameOver();
        }
    }
    private void gameOver()
    {
         Time.timeScale = 0;
        if (NextPanel != null)
        {
            NextPanel.SetActive(true);
        }
    }
}
