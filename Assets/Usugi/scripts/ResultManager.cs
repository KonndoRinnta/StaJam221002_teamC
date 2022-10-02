using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���U���g��ʂ̃}�l�[�W���[�p�N���X
/// �X�R�A�\���֘A���s��
/// </summary>
public class ResultManager : MonoBehaviour
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
        //�u�ō��L�^�v�\��������
        _scoreTextList[2].gameObject.SetActive(false);

        LoadDate();

        SetText();

        SaveDate();
    }

    /// <summary>
    /// �ۑ�����Ă���ō��X�R�A�ƒ��߂̃X�R�A�����[�h����
    /// </summary>
    void LoadDate()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");

        _lastScore = ScoreSystem._score;
    }

    /// <summary>
    /// �X�R�A���e�L�X�g�ɃZ�b�g����
    /// �ō��X�R�A���X�V�����Ƃ��́u�ō��L�^�v��\������
    /// </summary>
    public void SetText()
    {
        _scoreTextList[0].text = $"�n�C�X�R�A�F{_highScore}";
        _scoreTextList[1].text = $"����̃X�R�A�F{_lastScore}";

        if (_lastScore >= _highScore)
        {
            _scoreTextList[2].gameObject.SetActive(true);
        }
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

    void ChangeImage()
    {

    }
}
