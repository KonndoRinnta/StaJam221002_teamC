using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeSystem : MonoBehaviour
{
    [SerializeField, Tooltip("")] Text _timerText;
    [SerializeField, Tooltip("")] Text _countDownText;
    [SerializeField, Tooltip("")] string _finishText = "�����";
    [SerializeField, Tooltip("")] float _endTime;
    [SerializeField, Tooltip("")] float _finishDelayTime = 2f;
    [SerializeField, Tooltip("")] string _resultSceneName;
    [SerializeField] GameObject _gameOverSound;

    float _countDown = 3.5f;
    float _timer;

    /// <summary>�Q�[�����ł��邱�Ƃ�\���ϐ�</summary>
    public static bool _isGame;


    void Awake()
    {
        _timer = _endTime;
        _gameOverSound.SetActive(false);
    }


    void FixedUpdate()
    {
        TimeChange();
    }


    /// <summary>�J�E���g�_�E���ƃ^�C���̊Ǘ����s�����\�b�h</summary>
    void TimeChange()
    {
        if (!_isGame)
        {
            //�J�E���g�_�E��
            _countDown -= Time.deltaTime;

            _countDownText.text = Mathf.Floor(_countDown).ToString();
        }
        else
        {
            //�^�C�}�[
            _timer -= Time.deltaTime;

            _timerText.text = _timer.ToString("F2");
        }

        if (_countDown < 1)
        {
            //�J�E���g�_�E�����I�������Q�[�����J�n
            _countDownText.text = "";
            _isGame = true;
        }

        if (_timer <= 0)
        {
            //�^�C�}�[���O�ɂȂ�����Q�[���I��
            _timerText.text = "0000";
            _gameOverSound.SetActive(true);
            StartCoroutine(GameOver());
        }
    }


    IEnumerator GameOver()
    {
        _isGame = false;
        _countDownText.text = _finishText;
        yield return new WaitForSeconds(_finishDelayTime);
        SceneManager.LoadScene(_resultSceneName);
    }
}
