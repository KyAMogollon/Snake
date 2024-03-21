using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : GenericSingleton<GameManager>
{

    [SerializeField] GameObject food;
    public Vector2[] limites = new Vector2[2];
    private int maxScore;

    private float gameAreaWidth = 28f;
    private float gameAreaHeight = 28f;
    void Start()
    {
        limites[0]=new Vector2(-gameAreaWidth / 2, -gameAreaHeight / 2);
        limites[1]= new Vector2(gameAreaWidth / 2, gameAreaHeight / 2);
        GenerarComida();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetMaxScore(int highScore)
    {
        maxScore = highScore;
    }
    public int SetMaxScore()
    {
        return maxScore;
    }
    public void GenerarComida()
    {

        float randomX = Random.Range(limites[0].x, limites[1].x);
        float randomY = Random.Range(limites[0].y, limites[1].y);

        Instantiate(food, new Vector3(Mathf.Round(randomX), Mathf.Round(randomY), 0f), Quaternion.identity);
    }
}
