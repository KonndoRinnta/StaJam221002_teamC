using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �X�R�A��\������N���X
/// 
/// �@�\
/// �X�R�A���󂯎���ĕ\������
/// 
/// MEMO
/// �ȑO�̃X�R�A�ǂݍ���
/// �X�R�A�󂯂Ƃ�
/// ���X�g�Ɋi�[���Đ�����
/// �\��
/// �ۑ�
/// 
/// </summary>
public class Score : MonoBehaviour
{
    /// <summary>�n�C�X�R�A</summary>
    [SerializeField] int _highScore;

    /// <summary>�Ō�̃Q�[���ł̃X�R�A</summary>
    [SerializeField] int _lastScore;
    public int LastScore { set => _lastScore = value; }

    /// <summary>�\������e�L�X�g�̃��X�g</summary>
    [SerializeField] List<Text> _scoreTextList;

    // Start is called before the first frame update
    void Start()
    {
        LoadDate();

        SetText();

        SaveDate();
    }

    /// <summary>
    /// �X�R�A���e�L�X�g�ɃZ�b�g����
    /// </summary>
    private void SetText()
    {
        _scoreTextList[0].text = $"�n�C�X�R�A�F{_highScore}";
        _scoreTextList[1].text = $"�X�R�A�F{_lastScore}";
    }

    /// <summary>
    /// �f�[�^�����[�h����
    /// </summary>
    void LoadDate()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");
    }

    /// <summary>
    /// �n�C�X�R�A�ƌ��݂̃X�R�A���r���ăf�[�^���Z�[�u����
    /// </summary>
    void SaveDate()
    {
        if (_lastScore > _highScore)
        {
            PlayerPrefs.SetInt($"HighScore", _lastScore);
        }
    }
}