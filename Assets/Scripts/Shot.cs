using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private float moveVolume = 3f; //移動量

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(this.gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, moveVolume * Time.deltaTime));
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
