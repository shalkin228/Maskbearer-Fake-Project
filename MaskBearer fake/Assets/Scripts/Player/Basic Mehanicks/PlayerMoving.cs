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

    public bool isFlipping;
    public bool isDashing;
    public bool canInput;

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
        _animator.SetFloat("VelocityY", _rigidbody2D.velocity.y);
        _animator.SetBool("IsGrounded", _groundCheck.isGrounded);

        if (_isMoving && _dir == Direction.Right && !isDashing)
        {
            _rigidbody2D.drag = 0f;
            if (_rigidbody2D.velocity.x < _movingMaxSpeed)
                _rigidbody2D.velocity = new Vector2
                    (_rigidbody2D.velocity.x + _movingAddingSpeed, _rigidbody2D.velocity.y);

            if(transform.rotation != Quaternion.identity && !isFlipping)
            {
                _animator.SetTrigger("Turn");
                isFlipping = true;
            }
        }
        else if (_isMoving && _dir == Direction.Left && !isDashing)
        {
            _rigidbody2D.drag = 0f;
            if (_rigidbody2D.velocity.x > -_movingMaxSpeed)
                _rigidbody2D.velocity = new Vector2
                    (_rigidbody2D.velocity.x + -_movingAddingSpeed, _rigidbody2D.velocity.y);

            if (transform.rotation != new Quaternion(0, 180, 0, 0) && !isFlipping)
            {
                _animator.SetTrigger("Turn");
                isFlipping = true;
            }
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
    }

    public void Jump()
    {
        if (_groundCheck.isGrounded && canInput)
        {
            isFlipping = false;
            Flip();

            OnStartMoving.Invoke();

            _animator.SetTrigger("Jump");

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

        if (!canInput)
            return;

        _animator.SetBool("isRunning", true);

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
        if (!canInput)
            return;

        _isMoving = false;

        _animator.SetBool("isRunning", false);
    }

    public void Flip()
    {
        isFlipping = false;

        if (_dir == Direction.Right)
        {
            transform.rotation = Quaternion.identity;
        }
        else
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }

    public void InputBlockAndGoingDirection(AfterTransitionsDirection dir, float movingTime)
    {
        if(dir == AfterTransitionsDirection.GoRight)
        {
            _dir = Direction.Right;
        }
        if (dir == AfterTransitionsDirection.GoLeft)
        {
            _dir = Direction.Left;
        }
        canInput = false;
        _isMoving = true;
        GetComponent<PlayerDash>()._canDash = false;

        _animator.SetBool("isRunning", true);

        StartCoroutine
            (InputBlockAndGoingDirectionCorrutine(dir, movingTime));
    }

    public IEnumerator InputBlockAndGoingDirectionCorrutine(AfterTransitionsDirection dir, float movingTime)
    {
        yield return new WaitForSeconds(movingTime);
        canInput = true;
        _isMoving = false;
        GetComponent<PlayerDash>()._canDash = true;

        _animator.SetBool("isRunning", false);
    }

}
public enum Direction
{
    Right, Left
}
