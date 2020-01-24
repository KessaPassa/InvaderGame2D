using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{
    //透明化の速さ
    float speed = 0.02f;
    //A値を操作するための変数
    float alpha = 1f;
    //RGBを操作するための変数
    float red, green, blue;
    // フェードインかアウトか
    bool isFade = true;

    // Start is called before the first frame update
    void Start()
    {
        red = GetComponent<Text>().color.r;
        green = GetComponent<Text>().color.g;
        blue = GetComponent<Text>().color.b;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown){
            GameManager.instance.StartGame();
            gameObject.SetActive(false);
        }

        if (alpha >= 1)
            isFade = true;
        else if (alpha <= 0)
            isFade = false;

        if (isFade)
            alpha -= speed;
        else
            alpha += speed;
        GetComponent<Text>().color = new Color(red, green, blue, alpha);
    }
}
