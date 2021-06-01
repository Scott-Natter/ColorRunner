using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour
{
    private int time = 0;
    public Text score;
    public Text highscore;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Highscore") == true)
            highscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
        else
            highscore.text ="Highscore: -";
        
        StartTimer();
    }

    public void StartTimer()
    {
        time = 0;
        InvokeRepeating("IncrementTime", 1, 1);
    }

    public void StopTimer()
    {
        CancelInvoke();
        if(PlayerPrefs.GetInt("Highscore") < time)
            SetHighscore();
    }

    //Not a button
    public void SetHighscore()
    {
        PlayerPrefs.SetInt("Highscore", time);
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
    }

    public void ClearHighscores()
    {
        PlayerPrefs.DeleteKey("Highscore");
        highscore.text = "Highscore: -";
    }

    void IncrementTime()
    {
        time += 25;
        score.text = "Score: " + time;
        if(PlayerPrefs.GetInt("Highscore") < time)
            SetHighscore();
    }



}
