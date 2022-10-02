using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// リザルトマネージャーから値を受け取って表示する
/// </summary>
public class ResultUIManager : MonoBehaviour
{
    /// <summary>表示するテキストのリスト</summary>
    [SerializeField] List<Text> _scoreTextList;

    [SerializeField] 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// スコアをテキストにセットする
    /// </summary>
    public void SetText()
    {
        //_scoreTextList[0].text = $"ハイスコア：{_highScore}";
        //_scoreTextList[1].text = $"スコア：{_lastScore}";
    }
}
