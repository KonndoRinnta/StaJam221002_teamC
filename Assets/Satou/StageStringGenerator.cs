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
            // F:�� S:��� H:�n�[�t�u���b�N

            // 4�i�ڂ�S�����ɂ���
            _stageStr[3, i] = "F";

            // 3�i�ڂ̓����_���ŏ��ɂ���
            bool isThirdRowStep = Random.Range(0, 2) == 1 ? true : false;
            _stageStr[2, i] = isThirdRowStep ? "F" : "S";

            // 2�i�ڂ͐^���Ƃ��̍��E�̂����Ȃ烉���_���Ńn�[�t�u���b�N�ɂ���
            // ��ʍ��[�Ȃ�
            if (i == 0)
            {
                // �^���Ƃ��̉E�����Ȃ�
                if (_stageStr[2, 0] == "F" && _stageStr[2, 1] == "F")
                {
                    // �����_���Ńn�[�t�u���b�N�ɂ���
                    bool isSecondRowStep = Random.Range(0, 2) == 1 ? true : false;
                    _stageStr[1, 0] = isSecondRowStep ? "H" : "S";
                }
                else
                {
                    // ��ɂ���
                    _stageStr[1, 0] = "S";
                }
            }
            // ��ʉE�[�Ȃ�
            else if (i == _width - 1)
            {
                // �^���Ƃ��̍������Ȃ�
                if (_stageStr[2, _width - 1] == "F" && _stageStr[2, _width - 2] == "F")
                {
                    // �����_���Ńn�[�t�u���b�N�ɂ���
                    bool isSecondRowStep = Random.Range(0, 2) == 1 ? true : false;
                    _stageStr[1, _width - 1] = isSecondRowStep ? "H" : "S";
                }
                else
                {
                    // ��ɂ���
                    _stageStr[1, _width - 1] = "S";
                }
            }
            // ��ʒ[�ȊO�Ȃ�
            else
            {
                // �^���Ƃ��̍��E�����Ȃ�
                if (_stageStr[2, i - 1] == "F" && _stageStr[2, i] == "F" && _stageStr[2, i + 1] == "F")
                {
                    // �����_���Ńn�[�t�u���b�N�ɂ���
                    bool isSecondRowStep = Random.Range(0, 2) == 1 ? true : false;
                    _stageStr[1, i] = isSecondRowStep ? "H" : "S";
                }
                else
                {
                    // ��ɂ���
                    _stageStr[1, i] = "S";
                }
            }
            // 1�i�ڂ̓����_���Ńn�[�t�u���b�N�ɂ���
            // TODO:�S����ɂȂ��Ă���̂Ń����_���Ńn�[�t�u���b�N�ɂ��鏈�������
            bool isOneRowStep = Random.Range(0, 2) == 1 ? true : false;
            _stageStr[0, i] = isOneRowStep ? "P" : "S";
        }

        // �f�o�b�O�p
        string str = "";
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < _width; j++)
                str += _stageStr[i, j];
            str += "\n";
        }
        Debug.Log(str);

        return _stageStr;
    }
}
