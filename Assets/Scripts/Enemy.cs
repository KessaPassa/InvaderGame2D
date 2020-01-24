using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 破壊された時に加算されるスコア
    public int score;
    private ScoreController scoreController;

    // Start is called before the first frame update
    void Start()
    {
        scoreController = GameObject.FindObjectOfType<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        scoreController.AddScore(score);
    }
}
