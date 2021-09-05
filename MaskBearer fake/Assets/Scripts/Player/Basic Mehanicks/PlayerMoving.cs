using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float _movingMaxSpeed, _movingAddingSpeed, _stoppingLinearDrag, _jumpForce;
    [SerializeField] private UnityEvent OnStartMoving;
    private Rigidbody2D _rigidbody2D;
    private Player _inputActions;
    private bool _isMoving;
    private Direction _dir;
    private GroundCheck _groundCheck;
    private Animator _animator;

    public bool isDashing;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _groundCheck = GetComponentInChildren<GroundCheck>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _inputActions = new Player();
        _inputActions.Enable();

        _inputActions.PlayerInput.Horizontal.performed += ctx => Move(ctx.ReadValue<float>());
        _inputActions.PlayerInput.Horizontal.canceled += ctx => StopMove();

        _inputActions.PlayerInput.Jump.performed += ctx => Jump();
        _inputActions.PlayerInput.Jump.canceled += ctx => StopJump();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void Update()
    {
        if (_isMoving && _dir == Direction.Right && !isDashing)
        {
            _rigidbody2D.drag = 0f;
            if (_rigidbody2D.velocity.x < _movingMaxSpeed)
                _rigidbody2D.velocity = new Vector2
                    (_rigidbody2D.velocity.x + _movingAddingSpeed, _rigidbody2D.velocity.y);

            transform.rotation = Quaternion.identity;
        }
        else if (_isMoving && _dir == Direction.Left && !isDashing)
        {
            _rigidbody2D.drag = 0f;
            if (_rigidbody2D.velocity.x > -_movingMaxSpeed)
                _rigidbody2D.velocity = new Vector2
                    (_rigidbody2D.velocity.x + -_movingAddingSpeed, _rigidbody2D.velocity.y);

            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else if (_groundCheck.isGrounded)
        {
            _rigidbody2D.drag = _stoppingLinearDrag;
        }
        else
        {
            _rigidbody2D.drag = 0f;
        }

        if (_rigidbody2D.velocity.x == 0)
            _rigidbody2D.drag = 0f;
        else if (_rigidbody2D.velocity.y > 0)
        {
            _rigidbody2D.drag = 0;
        }

        _animator.SetBool("isRunning", Mathf.Abs(_rigidbody2D.velocity.x) > 0.1f);
    }

    public void Jump()
    {
        if (_groundCheck.isGrounded && !isDashing)
        {
            OnStartMoving.Invoke();

            _rigidbody2D.drag = 0;

            _groundCheck.isGrounded = false;

            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.y, _jumpForce);
        }
    }

    public void StopJump()
    {
        if(_rigidbody2D.velocity.y > 0 && !isDashing)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y * .5f);
        }
    }

    public void Move(float input)
    {
        if (Mathf.Abs(input) < .3f)
            return;

        _isMoving = true;

        OnStartMoving.Invoke();

        if (input > .01f)
        {
            _dir = Direction.Right;
        }
        else if (input < -.01f)
        {
            _dir = Direction.Left;
        }
    }

    public void StopMove()
    {
        _isMoving = false;
    }

}
public enum Direction
{
    Right, Left
}
