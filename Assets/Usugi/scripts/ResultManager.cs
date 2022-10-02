using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// リザルト画面のマネージャー用クラス
/// スコア表示関連を行う
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

    // Start is called before the first frame update
    void Start()
    {
        //「最高記録」表示を消す
        _scoreTextList[2].gameObject.SetActive(false);

        LoadDate();

        SetText();

        SaveDate();
    }

    /// <summary>
    /// 保存されている最高スコアと直近のスコアをロードする
    /// </summary>
    void LoadDate()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");

        _lastScore = ScoreSystem._score;
    }

    /// <summary>
    /// スコアをテキストにセットする
    /// 最高スコアを更新したときは「最高記録」を表示する
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

    void ChangeImage()
    {

    }
}
