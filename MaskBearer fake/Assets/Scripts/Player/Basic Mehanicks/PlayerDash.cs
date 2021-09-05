using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private AnimationCurve _dashCurve;
    [SerializeField] private float _dashCooldown;
    [SerializeField] private UnityEvent OnStartDash;
    private Player _inputActions;
    private bool _isDashing, _canDash;
    private float _timer;
    private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _inputActions = new Player();

        _canDash = true;

        _inputActions.Enable();
        _inputActions.PlayerInput.Dash.performed += ctx => Dash();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_isDashing && transform.rotation == Quaternion.identity && _canDash)
        {
            _rigidbody2D.MovePosition
                (new Vector2(
                    transform.position.x + _dashCurve.Evaluate(_timer),
                    transform.position.y));

            if(_timer > _dashCurve.keys[_dashCurve.keys.Length - 1].time)
            {
                _isDashing = false;

                GetComponent<PlayerMoving>().isDashing = false;
                GetComponentInChildren<WatchingDownAndUp>().isDashing = false;

                _rigidbody2D.gravityScale = 5;

                StartCoroutine(DashCooldown());
            }
        }
        else if (_isDashing && transform.rotation == new Quaternion(0,180,0,0) && _canDash)
        {
            _rigidbody2D.MovePosition
                (new Vector2(
                    transform.position.x + -_dashCurve.Evaluate(_timer),
                    transform.position.y));
            if (_timer > _dashCurve.keys[_dashCurve.keys.Length - 1].time)
            {
                _isDashing = false;

                GetComponent<PlayerMoving>().isDashing = false;
                GetComponentInChildren<WatchingDownAndUp>().isDashing = false;

                _rigidbody2D.gravityScale = 5;

                StartCoroutine(DashCooldown());
            }
        }
    }

    private void Dash()
    {
        if (!_canDash || _isDashing)
            return;

        OnStartDash.Invoke();

        _isDashing = true;
        _timer = 0;

        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.gravityScale = 0;

        GetComponent<PlayerMoving>().isDashing = true;
        GetComponentInChildren<WatchingDownAndUp>().isDashing = true;
    }

    private IEnumerator DashCooldown()
    {
        _canDash = false;

        yield return new WaitForSeconds(_dashCooldown);

        _canDash = true;
    }
}
