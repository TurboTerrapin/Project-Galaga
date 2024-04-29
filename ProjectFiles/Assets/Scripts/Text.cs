using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{

    public int textType;


    private string text;

    private Scoreboard scoreboard;
    private Player player;
    private TextMeshProUGUI textMesh;
    private Canvas canvas;
    private RectTransform canvasTransform;

    // Start is called before the first frame update
    void Start()
    {
        scoreboard = GameObject.Find("ScoreKeeper").GetComponent<Scoreboard>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        textMesh = gameObject.GetComponent<TextMeshProUGUI>();
        canvasTransform = canvas.gameObject.GetComponent<RectTransform>();
        switch (textType)
        {
            case 0:
                text = "Score: ";
                break;
            case 1:
                text = "Lives: ";
                break;
            case 2:
                text = "Current Upgrade: ";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (textType)
        {
            case 0:
                textMesh.text = text + scoreboard.score;
                textMesh.rectTransform.anchoredPosition = new Vector2(canvasTransform.position.x - 90, canvasTransform.position.y - 30);
                break;
            case 1:
                textMesh.text = text + scoreboard.lives;
                textMesh.rectTransform.anchoredPosition = new Vector2(canvasTransform.position.x - 90, canvasTransform.position.y - 60);
                break;
            case 2:
                textMesh.text = text + "Lol";
                break;
        }

    }
}
