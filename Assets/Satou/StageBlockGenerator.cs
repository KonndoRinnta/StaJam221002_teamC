using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBlockGenerator : MonoBehaviour
{
    // ���ƂȂ�u���b�N
    [SerializeField] GameObject _floorBlock;
    // �n�[�t�u���b�N�ƂȂ�u���b�N
    [SerializeField] GameObject _harfBlock;

    void Start()
    {
        // ��ʂ̔����̒������擾����
        int harf = /*Screen.width / 2*/ -1;

        StageStringGenerator ssg = GetComponent<StageStringGenerator>();
        if (ssg != null)
        {
            string[,] str = ssg.Generate();

            for (int i = 0; i < str.GetLength(0); i++)
            {
                for (int j = 0; j < str.GetLength(1); j++)
                {
                    if (str[i, j] == "F")
                    {
                        Instantiate(_floorBlock, new Vector3(harf + j, -i, 0), Quaternion.identity);
                    }
                    else if (str[i, j] == "H")
                    {
                        Instantiate(_harfBlock, new Vector3(harf + j, -i, 0), Quaternion.identity);
                    }
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
