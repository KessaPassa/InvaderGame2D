using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    //弾の発射数を制限
    private int canShotCount;
    public int maxShotCount;
    private float appearMargin = 0.5f;

    public GameObject shotObj;

    void Start()
    {
        // 初期化
        canShotCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 上限より現在打ち出している数が少ないなら
        if (canShotCount < maxShotCount && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.S)))
        {
            //Resourcesフォルダからprefabを引っ張ってきて複製
            Instantiate(shotObj, new Vector2(transform.position.x, transform.position.y + appearMargin), Quaternion.identity);
            canShotCount++;
        }
    }

    // ショットできる回数を戻す
    public void ReturnShot()
    {
        if(0 <= canShotCount)
        {
            canShotCount--;
        }
    }
}
