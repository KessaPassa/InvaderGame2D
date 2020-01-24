using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    private static float monitorLeft = float.NaN;
    private static float monitorRight = float.NaN;
    private static float player_width = float.NaN;

    // 画面外に出ないように調整した位置情報を返す
    public static Vector2 GetClampedPosition(Vector2 pos, float margin=0f)
    {
        // オブジェクト情報は最初の1度だけ実行して保存
        if(monitorLeft is float.NaN && monitorRight is float.NaN && player_width is float.NaN)
        {
            monitorLeft = GameObject.Find("OutOfGames/Left").transform.position.x;
            monitorRight = GameObject.Find("OutOfGames/Right").transform.position.x;
        }

        float left = monitorLeft + margin;
        float right = monitorRight - margin;

        // 最小と最大を決める。その範囲内ならそのまま返す
        float clampedX = Mathf.Clamp(pos.x, left, right);
        // ドット移動させたいので1ずつ整数値で動かす
        clampedX = Mathf.RoundToInt(clampedX);
        return new Vector2(clampedX, pos.y);
    }
}
