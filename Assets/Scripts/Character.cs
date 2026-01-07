using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private Animator _animator;
    private DamageTaker _damageTaker;
    
    private float _moveInput;
    private float _jumpInput;
    private float _time;
    private bool _canMove;
    public bool _isHit = false;
    public bool _isDead = false;
    public bool _isSliding = false;
    [SerializeField] private float _XSpeed = 10;
    [SerializeField] private float _JumpForce = 500;
    [SerializeField] Detector _groundDetector;
    [SerializeField] Detector _leftDetector;
    [SerializeField] Detector _rightDetector;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float MaxTime;
    [SerializeField] private float WallForce;
    [SerializeField] private float _hitForce;
    
    //[SerializeField] private Transform _camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _damageTaker = GetComponent<DamageTaker>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rb.linearVelocityY >= maxVelocity)
        {
            _rb.linearVelocityY = maxVelocity;
        }
        if (_canMove)
        {
            _rb.linearVelocityX = _moveInput * _XSpeed;
        }
        if (_time <= 0)
        {
            _canMove = true;
        }
        _time -= Time.deltaTime;
    }

    private void Update()
    {
        //if(_rb.linearVelocityX < 0) _sr.flipX = true;
        //if(_rb.linearVelocityX > 0) _sr.flipX = false;
        
        _animator.SetFloat("velX", Mathf.Abs(_rb.linearVelocityX));
        _animator.SetFloat("jump", Mathf.Abs(_rb.linearVelocityY));   
        _animator.SetBool("IsHit", _isHit );
        _animator.SetBool("IsDead", _isDead);
        _animator.SetBool("WallSilde", _isSliding);
        FlipSprite();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hazard")|| other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hazard Touché !");
            
            _isHit = true;
            _rb.linearVelocity = Vector2.zero;
            
            Vector2 knockbackDir = (transform.position - other.transform.position).normalized;
            _rb.AddForce(knockbackDir * _hitForce, ForceMode2D.Impulse);
            
            if (_damageTaker != null)
            {
                _damageTaker.TakeDamage(1f);
                
            }
            

            StopCoroutine("ResetHit_co");
            StartCoroutine("ResetHit_co");
        }  Debug.Log("Hit what ?" + other.gameObject.name);
       
    }
    
    public void SetDead()
    {
        _isDead = true;
        _canMove = false; 
        _rb.linearVelocity = Vector2.zero;
        Debug.Log("dead !");
    }

   

    public void OnMove(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>().x;
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (_groundDetector.Touched && ctx.started)
        {
            _rb.AddForce(_rb.linearVelocity * (-1.0f * _hitForce), ForceMode2D.Impulse);
            _rb.AddForce(Vector2.up * _JumpForce, ForceMode2D.Impulse);
            Debug.Log("Do a flip");
        }
        
        if (!_groundDetector.Touched)
        {
            if (_leftDetector.Touched)
            {
                _isSliding = true;
                _rb.AddForce(new Vector2(1,1).normalized * WallForce, ForceMode2D.Impulse);
                _canMove = false;
                _sr.flipX = false;
                _time = MaxTime;
            }
            if (_rightDetector.Touched)
            {
                _isSliding = true;
                _rb.AddForce(new Vector2(-1,1).normalized * WallForce, ForceMode2D.Impulse);
                _canMove = false;
                _sr.flipX = true;
                _time = MaxTime;
            }
        }
        else
        {
            _isSliding = false;
        }
        
    }

    private void FlipSprite()
    {
        if(_moveInput > 0.1)
        {
            _sr.flipX = false;
        }
        if(_moveInput < -0.1)
        {
            _sr.flipX = true;
        }
    }
    
    IEnumerator ResetHit_co()
    {
        yield return new WaitForSeconds(0.5f);
        _isHit = false;
    }
}
