using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamageable
{
    public Rigidbody2D _rigid;
    [SerializeField]
    private float jumpForce = 5.0f;
    private bool _resetJump = false;
    [SerializeField]
    private float _speed = 8.0f;
    private bool _grounded = false;
    private PlayerAnimation _playerAnim;
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _swordArcSprite;
    private bool isDeath = false;
    private bool isHit = false;

    public int Health { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        //assign handle to playerAnimation
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if(isHit == true || isDeath == true)
        {
            _rigid.velocity = Vector2.zero;
            Vector2 a = new Vector2(0, -50);
            _rigid.AddForce(a);
        }
        if(isDeath == false)
        {
            if(isHit == false)
            {
                Movement();

                //left click to swing sword
                if (Input.GetMouseButtonDown(0) && IsGrounded() == true)
                {
                    _playerAnim.Swing();
                }
            }      
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        _grounded = IsGrounded();

        if (move > 0)
        {
            Flip(false);
        }
        else if (move < 0)
        {
            Flip(true);
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && IsGrounded() == true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, jumpForce);
            StartCoroutine(ResetJumpRoutine());
            _playerAnim.Jump(true);
        }

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);

        _playerAnim.Move(move);
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 8);
        //Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
            {
                _playerAnim.Jump(false);
                return true;
            }
        }
        return false;
    }
    void Flip(bool faceLeft)
    {
        if (faceLeft == false)
        {
            _playerSprite.flipX = false;
            _swordArcSprite.flipY = false;

            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = 0.73f;
            newPos.y = 0.54f;
            _swordArcSprite.transform.localPosition = newPos;
        }
        else
        {
            _playerSprite.flipX = true;
            _swordArcSprite.flipY = true;

            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = -0.4f;
            newPos.y = 0.39f;
            _swordArcSprite.transform.localPosition = newPos;

        }
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    IEnumerator SetDeathState()
    {
        _playerAnim.Death();
        isDeath = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }
    IEnumerator SetHitState()
    {
        _playerAnim.Hit();
        isHit = true;
        yield return new WaitForSeconds(1.5f);
        isHit = false;
    }

    public void Damage()
    {
        if (Health < 1) return;
        Debug.Log("Player::Damage()");
        
        Health--;
        if(Health<1)
        {
            StartCoroutine(SetDeathState());
        }
        if(isDeath == false)
        {
            StartCoroutine(SetHitState());
        }
        
    }

    public void Spike()
    {
        if(isDeath == false)
        {
            StartCoroutine(SetDeathState());
        }        
    }
}
