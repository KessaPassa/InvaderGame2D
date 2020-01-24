using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        AddTime(time);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.IsGaming())
        {
            time += Time.deltaTime;
            AddTime(time);
        }
    }

    void AddTime(float num)
    {
        GetComponent<Text>().text = "Time: " + num.ToString("f2");
    }
}
