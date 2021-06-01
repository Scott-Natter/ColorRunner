using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject highscoreUI;
    public GameObject gameOverUI;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Player")
            Time.timeScale = 0;
            gameOverUI.SetActive(true);

    }
}
