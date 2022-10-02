using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("移動のスピード")] float _moveSpeed = 20;
    [SerializeField, Tooltip("ジャンプの力")] float _jumpPower = 10f;
    [SerializeField, Tooltip("ジャンプ可能な回数")] int _jumpLimit = 1;

    [Tooltip("ジャンプの回数")] int _jumpCount;
    [Tooltip("x軸の入力判定")] float _inputX;
    [Tooltip("Flipのために値を保存しておく用の変数")] float _x = 1;
    [Tooltip("ジャンプの入力判定")] bool _isJump;

    [SerializeField] AudioSource _audio;

    Rigidbody2D _rb;
    SpriteRenderer _spriteRenderer;
    Animator _animator;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        _inputX = Input.GetAxisRaw("Horizontal");

        Jump();
    }


    void FixedUpdate()
    {
        MoveHorizontal();
        PlayerFlip();

        //Animatorの処理
        _animator.SetFloat("MoveX", _rb.velocity.x);
        _animator.SetBool("IsJump", _isJump);
    }


    /// <summary>プレイヤーを回転させるメソッド</summary>
    void PlayerFlip()
    {
        if (_inputX != 0)
        {
            _x = _inputX;
        }

        if (_x > 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }


    /// <summary>横方向の移動を行うメソッド</summary>
    void MoveHorizontal()
    {
        _rb.velocity = new Vector2(_inputX * _moveSpeed, _rb.velocity.y);
    }


    /// <summary>ジャンプの処理を行うメソッド</summary>
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (_jumpCount < _jumpLimit && !_isJump)
            {
                _audio.Play();
                _rb.velocity = Vector2.zero;
                _rb.AddForce(transform.up * _jumpPower, ForceMode2D.Impulse);
                _isJump = true;
                _jumpCount++;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //接地判定
        if (collision.gameObject.tag == "Ground")
        {
            _jumpCount = 0;
            _isJump = false;
        }
    }
}
