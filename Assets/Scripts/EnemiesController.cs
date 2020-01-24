using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PositionManager
{
    private readonly float startY = 0f;
    private readonly float endY = 4f;

    private List<float> rangeX = new List<float>();
    private List<float> rangeY = new List<float>();

    public PositionManager(int y, int x, Vector2 padding)
    {
        float intervalY = Mathf.Abs(startY - endY) / y + padding.y;
        for(int i = 0; i < y; i++)
        {
            rangeY.Add(startY + intervalY * i);
        }

        // 中央に敵が均等配置されるように、x軸が偶数と奇数によって調整する
        // 中央から左右均等に外側に配置する
        float before = -1;
        for (int posX = x % 2 == 0 ? 0 : 1; posX < x+(x % 2 == 0 ? 0 : 1); posX++)
        {
            float ceil = Mathf.CeilToInt(posX / 2);
            ceil += padding.x * ceil;
            // 前回と同じ値ならマイナスにして反対側に配置する
            if (before == ceil)
                ceil *= -1;
            before = ceil;
            rangeX.Add(ceil);
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
public class EnemiesController : MonoBehaviour
{
    // 敵の種類 == y軸
    private int kindOfEnemies = 5;
    // 一列に配置する敵の数 == x軸
    private int countLineEnemies = 6;
    // 敵を配置する時の間隔
    private Vector2 padding = new Vector2(0.5f, 0f);
    // 横移動する時の移動幅を狭めて調整する
    private float margin = 4f;
    //移動量
    private float moveSpeed = 1f;
    // ゲームがスタートされたときにupdate関数で1回だけ実行したい用
    bool isCalledOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        var posManager = new PositionManager(kindOfEnemies, countLineEnemies, padding);
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
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCalledOnce && GameManager.instance.IsGaming())
        {
            StartCoroutine(MovePerSeconds());
            isCalledOnce = true;
        }
    }

    // 横移動を継続したいのでStart関数から1度実行してwhileでループ
    IEnumerator MovePerSeconds()
    {
        Vector2 beforePos;
        while (true)
        {
            beforePos = transform.position;
            Vector2 newPos = Utils.GetClampedPosition(new Vector2(transform.position.x + moveSpeed, transform.position.y), margin);
            // 端まで行ったら反転する
            if(beforePos == newPos)
            {
                moveSpeed *= -1f;
                newPos = new Vector2(newPos.x + moveSpeed, newPos.y);
            }
            transform.position = newPos;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
