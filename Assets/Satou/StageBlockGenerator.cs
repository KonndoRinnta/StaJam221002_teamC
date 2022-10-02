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
                    if (str[i, j] == "F")
                    {
                        var go = Instantiate(_floorBlock, new Vector3(offsetX + j, -1 * i + offsetY, 0), Quaternion.identity);
                        go.transform.SetParent(transform);
                    }
                    else if (str[i, j] == "H")
                    {
                        var go = Instantiate(_harfBlock, new Vector3(offsetX + j, -1 * i + offsetY, 0), Quaternion.identity);
                        go.transform.SetParent(transform);
                    }
                    else if (str[i, j] == "P")
                    {
                        var go = Instantiate(_platformBlock, new Vector3(offsetX + j, -1 * i + offsetY, 0), Quaternion.identity);
                        go.transform.SetParent(transform);
                    }
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
