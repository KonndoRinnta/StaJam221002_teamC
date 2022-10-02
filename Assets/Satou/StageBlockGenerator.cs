using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 文字列からブロックを生成してステージを作る
/// </summary>
public class StageBlockGenerator : MonoBehaviour
{
    /// <summary>床となるブロック</summary>
    [SerializeField] GameObject _floorBlock;
    /// <summary>ハーフブロックとなるブロック</summary>
    [SerializeField] GameObject _harfBlock;
    /// <summary>プラットフォームとなるブロック</summary>
    [SerializeField] GameObject _platformBlock;

    void Start()
    {
        // XとY方向にそれぞれずらす
        float offsetX = -8.5f;
        float offsetY = -1.5f;

        StageStringGenerator ssg = GetComponent<StageStringGenerator>();
        if (ssg != null)
        {
            string[,] str = ssg.Generate();

            for (int i = 0; i < str.GetLength(0); i++)
            {
                for (int j = 0; j < str.GetLength(1); j++)
                {
                    // 文字によって生成するブロックを変える
                    GameObject block = null;
                    if (str[i, j] == "F")
                        block = _floorBlock;
                    else if (str[i, j] == "H")
                        block = _harfBlock;
                    else if (str[i, j] == "P")
                        block = _platformBlock;

                    if (!block)
                    {
                        Debug.LogWarning("ブロックを生成できませんでした。対応する文字がないです。");
                        continue;
                    }

                    // ブロックを生成して親を登録する
                    var go = Instantiate(block, new Vector3(offsetX + j, -1 * i + offsetY, 0), Quaternion.identity);
                    go.transform.SetParent(transform);
                }
            }
        }
        else
        {
            Debug.LogWarning(nameof(ssg) + "を取得できませんでした。");
        }
    }

    void Update()
    {

    }
}
