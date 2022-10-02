using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����񂩂�u���b�N�𐶐����ăX�e�[�W�����
/// </summary>
public class StageBlockGenerator : MonoBehaviour
{
    /// <summary>���ƂȂ�u���b�N</summary>
    [SerializeField] GameObject _floorBlock;
    /// <summary>�n�[�t�u���b�N�ƂȂ�u���b�N</summary>
    [SerializeField] GameObject _harfBlock;
    /// <summary>�v���b�g�t�H�[���ƂȂ�u���b�N</summary>
    [SerializeField] GameObject _platformBlock;

    void Start()
    {
        // X��Y�����ɂ��ꂼ�ꂸ�炷
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
                    // �����ɂ���Đ�������u���b�N��ς���
                    GameObject block = null;
                    if (str[i, j] == "F")
                        block = _floorBlock;
                    else if (str[i, j] == "H")
                        block = _harfBlock;
                    else if (str[i, j] == "P")
                        block = _platformBlock;

                    if (!block)
                    {
                        Debug.LogWarning("�u���b�N�𐶐��ł��܂���ł����B�Ή����镶�����Ȃ��ł��B");
                        continue;
                    }

                    // �u���b�N�𐶐����Đe��o�^����
                    var go = Instantiate(block, new Vector3(offsetX + j, -1 * i + offsetY, 0), Quaternion.identity);
                    go.transform.SetParent(transform);
                }
            }
        }
        else
        {
            Debug.LogWarning(nameof(ssg) + "���擾�ł��܂���ł����B");
        }
    }

    void Update()
    {

    }
}
