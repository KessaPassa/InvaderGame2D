using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PositionManager
{
    private readonly float startX = -5f;
    private readonly float endX = 4f;
    private readonly float startY = -1f;
    private readonly float endY = 4f;

    private List<float> rangeX = new List<float>();
    private List<float> rangeY = new List<float>();

    public PositionManager(int y, int x, Vector2 margin)
    {
        float intervalY = Mathf.Abs(startY - endY) / y + margin.y;
        float intervalX = Mathf.Abs(startX - endX) / x + margin.x;

        for(int i=0; i < y; i++)
        {
            rangeY.Add(startY + intervalY * i);
        }
        for (int i = 0; i < x; i++)
        {
            rangeX.Add(startX + intervalX * i);
        }
    }

    public List<float> GetRangeX()
    {
        return rangeX;
    }

    public List<float> GetRangeY()
    {
        return rangeY;
    }
}


// Enemyを格納する空のGameObjectにスクリプトをアタッチする
public class Enemy : MonoBehaviour
{
    private int kindOfEnemies = 5;
    private int countLineEnemies = 6;
    private Vector2 margin = new Vector2(-0.5f, 0f);
    //移動量
    private float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        var posManager = new PositionManager(kindOfEnemies, countLineEnemies, margin);
        List<float> rangeX = posManager.GetRangeX();
        List<float> rangeY = posManager.GetRangeY();


        for (int y=0; y < kindOfEnemies; y++)
        {
            for (int x=0; x < countLineEnemies; x++)
            {
                //縦列ごとに敵の種類を変える
                GameObject obj = Resources.Load("nc128454_" + y) as GameObject;
                GameObject instance =
                    Instantiate(obj,
                    new Vector2(rangeX[x], rangeY[y]),
                    Quaternion.identity);

                // Enemiesの空オブジェクトを親オブジェクトにする
                instance.transform.parent = gameObject.transform;
            }
        }
        StartCoroutine(MovePerSeconds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MovePerSeconds()
    {
        while (true)
        {
            Vector2 newPos = new Vector2(transform.position.x + moveSpeed, transform.position.y);
            transform.position = Utils.GetClampedPosition(newPos);
            print("ほげ");
            yield return new WaitForSeconds(2f);
        }
    }
}
