using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Manager : MonoBehaviour
{
    public Text actualScore;
    public Text highScore;
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        actualScore.text = " Score: " + 0;
        highScore.text = " HighScore: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateText(int puntuacion)
    {
        actualScore.text = " Score: " + puntuacion;
    }
    public void MaxScore()
    {
        highScore.text = " HighScore: " + GameManager.Instance.SetMaxScore();
    }
}
