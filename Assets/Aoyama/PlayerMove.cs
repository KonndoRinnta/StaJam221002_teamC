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
    [Tooltip("ジャンプの入力判定")] bool _inputJump;
    [Tooltip("接地判定")] bool _isGround;

    Rigidbody2D _rb;
    Animator _animator;
    

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        _inputX = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump"))
        {
            _inputJump = true;
            _jumpCount++;
        }
        else
        {
            _inputJump = false;
        }

        _animator.SetFloat("MoveX", _rb.velocity.x);
        _animator.SetFloat("MoveY", _rb.velocity.y);
    }


    void FixedUpdate()
    {
        MoveHorizontal();
        Jump();
    }


    /// <summary>横方向の移動を行うメソッド</summary>
    void MoveHorizontal()
    {
        _rb.velocity = new Vector2(_inputX * _moveSpeed, _rb.velocity.y);
    }


    /// <summary>ジャンプの処理を行うメソッド</summary>
    void Jump()
    {
        if (_jumpCount < _jumpLimit)
        {
            _rb.AddForce(transform.up * _jumpPower);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //接地判定
        if (collision.gameObject.tag == "Ground")
        {
            _jumpCount = 0;
        }
    }
}
