using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    // 移動量
    private float moveVolume = 3f;
    // 破壊するy軸の領域を設定
    private float destroyPos = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, moveVolume * Time.deltaTime));
        // 領域外になったら削除(基本は動作しないが念のため)
        if(transform.position.y >= destroyPos)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //敵にあったったら削除する
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Block")
        {
            Destroy(gameObject);
        }
    }

    // 削除した分、発射制限を緩和
    private void OnDestroy()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<ShotController>().ReturnShot();
    }
}
