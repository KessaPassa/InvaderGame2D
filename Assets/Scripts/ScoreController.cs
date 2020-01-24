using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        AddScore(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int num)
    {
        score += num;
        GetComponent<Text>().text = "Score: " + score;
    }
}
