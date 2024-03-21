using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int actualScore=0;
    private int highScore=0;
    public UI_Manager _UIManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetActualScore()
    {
        actualScore = 0;
        _UIManager.UpdateText(actualScore);
    }
    public void UpdateScore(int puntuacion)
    {
        actualScore = actualScore + puntuacion;
        _UIManager.UpdateText(actualScore);
        if(actualScore > highScore)
        {
            highScore = actualScore;
            GameManager.Instance.GetMaxScore(highScore);
            _UIManager.MaxScore();
        }
    }
}
