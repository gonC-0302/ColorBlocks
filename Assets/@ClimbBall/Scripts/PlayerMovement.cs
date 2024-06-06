using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _moveSpeed;
    public float _jumpPower;
    //public AudioClip jumpSound;
    private Rigidbody2D _rb2d;
    private bool _isJump;
    private float _jumpTimer;
    private float _jumpInterval= 0.1f;
    private bool _isGameStart;
    [SerializeField] private GoalFlag _flag;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    public void StartGame()
    {
        _isGameStart = true;
    }

    void FixedUpdate()
    {
        if (!_isGameStart) return;
        float moveX = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveX, 0);
        _rb2d.AddForce(movement * _moveSpeed);
    }

    private void Update()
    {
        if (!_isGameStart) return;
        if (Input.GetKeyDown(KeyCode.Space) && !_isJump)
        {
            Jump();
        }
       
        CheckGround();

        if(transform.position.y < -5)
        {
            GameOver();
        }

    }

    private void GameOver()
    {
        _flag.FinishGame(false);
        Destroy(gameObject);

    }

    private void CheckGround()
    {
        if (_isJump)
        {
            _jumpTimer += Time.deltaTime;
            if (_jumpTimer < _jumpInterval) return;
        }
        Vector2 StartPosition = transform.position;
        //移動判定用　衝突するレイヤーはすべて入れる
        int LayerObject = LayerMask.GetMask(new string[] { "Tile" });
        //Raycastで下方向に特定タグの付いたオブジェクトが無いかを検出
        RaycastHit2D HitObject = Physics2D.Raycast(StartPosition, Vector2.down, 0.16f, LayerObject);
        //Debug.DrawRay(StartPosition, Vector2.down * 0.16f, Color.red,1f);
        //衝突判定を戻す
        if(HitObject)
        {
            _isJump = false;
        }
        else
        {
            _isJump = true;
        }
    }

    void Jump()
    {
        _jumpTimer = 0;
        _rb2d.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        _isJump = true;
        //AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position);
    }
}
