using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestnutGenerator : MonoBehaviour
{
    [Header("Generate")]
    [SerializeField] Transform[] _generatePosition;
    [SerializeField] int _generateMinInterval = 1;
    [SerializeField] int _generateMaxInterval = 3;
    [Header("Prefab")]
    [SerializeField] GameObject[] _chestnutPrefab;

    float _generateInterval;
    float _timer;

    void Start()
    {
        _generateInterval = Random.Range(_generateMinInterval, _generateMaxInterval);
    }

    
    void Update()
    {
        RandomGenerateChestnut();
    }


    void RandomGenerateChestnut()
    {
        int generatePosNum;
        int chestNum;

        if (TimeSystem._isGame)
        {
            _timer += Time.deltaTime;
        }

        if (_timer > _generateInterval / 10)
        {
            generatePosNum = Random.Range(0, _generatePosition.Length);
            chestNum = Random.Range(0, _chestnutPrefab.Length);

            Instantiate(_chestnutPrefab[chestNum], _generatePosition[generatePosNum]);

            _generateInterval = Random.Range(_generateMinInterval, _generateMaxInterval);
            _timer = 0;
        }
    }
}
