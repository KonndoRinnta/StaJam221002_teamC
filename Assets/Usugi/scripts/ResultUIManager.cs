using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���U���g�}�l�[�W���[����l���󂯎���ĕ\������
/// </summary>
public class ResultUIManager : MonoBehaviour
{
    /// <summary>�\������e�L�X�g�̃��X�g</summary>
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
    /// �X�R�A���e�L�X�g�ɃZ�b�g����
    /// </summary>
    public void SetText()
    {
        //_scoreTextList[0].text = $"�n�C�X�R�A�F{_highScore}";
        //_scoreTextList[1].text = $"�X�R�A�F{_lastScore}";
    }
}
