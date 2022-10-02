using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージのもとになる文字列をランダムに生成する
/// </summary>
public class StageStringGenerator : MonoBehaviour
{
    /// <summary>ステージの横の長さ</summary>
    [SerializeField] int _width;

    /// <summary>マップの文字列となる二次元配列</summary>
    string[,] _stageStr;

    void Start()
    {

    }

    void Update()
    {

    }

    /// <summary>マップの元になる文字列の二次元配列を生成する</summary>
    public string[,] Generate()
    {
        // 1段目はランダムにプラットフォーム
        // 2段目は中段が床だった場合はハーフブロック的なものにする
        // 3段目は床もしくは空
        // 4段目は全部床にする
        _stageStr = new string[4, _width];

        for (int i = 0; i < _width; i++)
        {
            // F:床 S:空間 H:ハーフブロック P:プラットフォーム

            // 4段目を全部床にする
            _stageStr[3, i] = "F";

            // 3段目はランダムで床にする
            bool isThirdRowStep = Random.Range(0, 2) == 1 ? true : false;
            _stageStr[2, i] = isThirdRowStep ? "F" : "S";

            // 1段目はランダムでプラットフォームブロックにする
            bool isOneRowStep = Random.Range(0, 2) == 1 ? true : false;
            _stageStr[0, i] = isOneRowStep ? "P" : "S";
        }

        // 2段目は真下とその左右が床ならランダムでハーフブロックにする
        for (int i = 0; i < _width; i++)
        {
            // 画面左端なら
            if (i == 0)
                SetHarfBlock(() => _stageStr[2, 0] == "F" && _stageStr[2, 1] == "F", index: 0);
            // 画面右端なら
            else if (i == _width - 1)
                SetHarfBlock(() => _stageStr[2, _width - 1] == "F" && _stageStr[2, _width - 2] == "F", index: _width - 1);
            // 画面端以外なら
            else
                _stageStr[1, i] = "S";
        }

        DispDebugLog();
        return _stageStr;
    }

    /// <summary>2段目の端は3段目の端と内側1ブロックが床ならハーフブロックを置く</summary>
    void SetHarfBlock(System.Func<bool> Condition, int index)
    {
        if (Condition.Invoke())
        {
            // ハーフブロックにする
            _stageStr[1, index] = "H";
        }
        else
        {
            // 空にする
            _stageStr[1, index] = "S";
        }
    }

    /// <summary>デバッグログに出力する</summary>
    void DispDebugLog()
    {
        string str = "";
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < _width; j++)
                str += _stageStr[i, j];
            str += "\n";
        }
        Debug.Log(str);
    }
}
