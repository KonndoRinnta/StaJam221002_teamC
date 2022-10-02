using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// スコアを表示するクラス
/// 
/// 機能
/// スコアを受け取って表示する
/// 
/// MEMO
/// 以前のスコア読み込む
/// スコア受けとる
/// リストに格納して整える
/// 表示
/// 保存
/// 
/// </summary>
public class ResultManager : MonoBehaviour
{
    /// <summary>ハイスコア</summary>
    [SerializeField] int _highScore;

    /// <summary>最後のゲームでのスコア</summary>
    [SerializeField] int _lastScore;
    public int LastScore { set => _lastScore = value; }

    /// <summary>表示するテキストのリスト</summary>
    [SerializeField] List<Text> _scoreTextList;

    [SerializeField] ResultUIManager _uImanager;

    // Start is called before the first frame update
    void Start()
    {
        _scoreTextList[2].gameObject.SetActive(false);

        LoadDate();

        SetText();

        SaveDate();
    }

    /// <summary>
    /// 保存されている最高スコアをロードする
    /// </summary>
    void LoadDate()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");
    }

    /// <summary>
    /// ハイスコアと現在のスコアを比較してデータをセーブする
    /// </summary>
    void SaveDate()
    {
        if (_lastScore > _highScore)
        {
            PlayerPrefs.SetInt($"HighScore", _lastScore);
        }
    }

    /// <summary>
    /// スコアをテキストにセットする
    /// </summary>
    public void SetText()
    {
        _scoreTextList[0].text = $"ハイスコア：{_highScore}";
        _scoreTextList[1].text = $"今回のスコア：{_lastScore}";

        if (_lastScore >= _highScore)
        {
            _scoreTextList[2].gameObject.SetActive(true);
        }
    }
}
