using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : Colors
{

    public GameColor characterColor = GameColor.Red;

    Renderer renderer;


    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.red);
    }

    void Update()
    {
        
    }


    public void NextColor()
    {
        Debug.Log("SPACE");
        switch(characterColor)
        {
            case GameColor.Red:
                Debug.Log("Red");
                characterColor = GameColor.Yellow;
                renderer.material.SetColor("_Color", Color.yellow);
                break;
            case GameColor.Yellow:
                Debug.Log("Yellow");
                characterColor = GameColor.Blue;
                renderer.material.SetColor("_Color", Color.blue);
                break;
            case GameColor.Blue:
                Debug.Log("Blue");
                characterColor = GameColor.Red;
                renderer.material.SetColor("_Color", Color.red);
                break;
        }
    }
}
