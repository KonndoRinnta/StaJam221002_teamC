using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X�e�[�W�̂��ƂɂȂ镶����������_���ɐ�������
/// </summary>
public class StageStringGenerator : MonoBehaviour
{
    /// <summary>�X�e�[�W�̉��̒���</summary>
    [SerializeField] int _width;

    /// <summary>�}�b�v�̕�����ƂȂ�񎟌��z��</summary>
    string[,] _stageStr;

    void Start()
    {

    }

    void Update()
    {

    }

    /// <summary>�}�b�v�̌��ɂȂ镶����̓񎟌��z��𐶐�����</summary>
    public string[,] Generate()
    {
        // 1�i�ڂ̓����_���Ƀv���b�g�t�H�[��
        // 2�i�ڂ͒��i�����������ꍇ�̓n�[�t�u���b�N�I�Ȃ��̂ɂ���
        // 3�i�ڂ͏��������͋�
        // 4�i�ڂ͑S�����ɂ���
        _stageStr = new string[4, _width];

        for (int i = 0; i < _width; i++)
        {
            // F:�� S:��� H:�n�[�t�u���b�N P:�v���b�g�t�H�[��

            // 4�i�ڂ�S�����ɂ���
            _stageStr[3, i] = "F";

            // 3�i�ڂ̓����_���ŏ��ɂ���
            bool isThirdRowStep = Random.Range(0, 2) == 1 ? true : false;
            _stageStr[2, i] = isThirdRowStep ? "F" : "S";

            // 1�i�ڂ̓����_���Ńv���b�g�t�H�[���u���b�N�ɂ���
            bool isOneRowStep = Random.Range(0, 2) == 1 ? true : false;
            _stageStr[0, i] = isOneRowStep ? "P" : "S";
        }

        // 2�i�ڂ͐^���Ƃ��̍��E�����Ȃ烉���_���Ńn�[�t�u���b�N�ɂ���
        for (int i = 0; i < _width; i++)
        {
            // ��ʍ��[�Ȃ�
            if (i == 0)
                SetTwoRow(() => _stageStr[2, 0] == "F" && _stageStr[2, 1] == "F", index: 0);
            // ��ʉE�[�Ȃ�
            else if (i == _width - 1)
                SetTwoRow(() => _stageStr[2, _width - 1] == "F" && _stageStr[2, _width - 2] == "F", index: _width - 1);
            // ��ʒ[�ȊO�Ȃ�
            else
                SetTwoRow(() => _stageStr[2, i - 1] == "F" && _stageStr[2, i] == "F" && _stageStr[2, i + 1] == "F", index: i);
        }

        DispDebugLog();
        return _stageStr;
    }

    /// <summary>2�i�ڂ̓u���b�N�̈ʒu�ɂ���ď������ς��̂Ŋ֐��ɂ���</summary>
    void SetTwoRow(System.Func<bool> Condition, int index)
    {
        // �^���Ƃ��̍��E�����Ȃ�
        if (Condition.Invoke())
        {
            // �����_���Ńn�[�t�u���b�N�ɂ���
            //bool isSecondRowStep = Random.Range(0, 2) == 1 ? true : false;
            _stageStr[1, index] = /*isSecondRowStep*/true ? "H" : "S";
        }
        else
        {
            // ��ɂ���
            _stageStr[1, index] = "S";
        }
    }

    /// <summary>�f�o�b�O���O�ɏo�͂���</summary>
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
