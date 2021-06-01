using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteColor : Colors
{
    public RectTransform selector;
    [SerializeField]
    private GameColor highlight;

    void Start()
    {

        highlight = GameColor.Red;
        selector = transform.Find("Selector").GetComponent<RectTransform>();;
        Debug.Log(selector);
    }

    public void NextColor()
    {
        switch(highlight)
        {
            case GameColor.Red:
                highlight = GameColor.Yellow;
                selector.anchoredPosition = new Vector2(0, 0);
                break;
            case GameColor.Yellow:
                highlight = GameColor.Blue;
                selector.anchoredPosition = new Vector2(0, -175);
                break;
            case GameColor.Blue:
                highlight = GameColor.Red;
                selector.anchoredPosition = new Vector2(0, 175);
                break;
        }
    }
}
