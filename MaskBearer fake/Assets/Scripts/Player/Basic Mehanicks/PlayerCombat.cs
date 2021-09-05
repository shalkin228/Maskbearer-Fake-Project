using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Transform _hitPoint;
    [SerializeField] private float _hitPointRadius, _coolDown, _linearStoppingDrag;
    [SerializeField] private UnityEvent OnStartHit;
    private Player _inputActions;
    private Animator _animator;
    private bool _canHit = true;
    private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _inputActions = new Player();

        _inputActions.Enable();
        _inputActions.PlayerInput.Hit.performed += ctx => Hit();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    public void Hit()
    {
        if (!_canHit)
            return;

        OnStartHit.Invoke();

        Collider2D[] collidingObjects =
            Physics2D.OverlapCircleAll(_hitPoint.position, _hitPointRadius);

        _animator.SetTrigger("Hit");

        if (_rigidbody2D.velocity.y > 0.01f || _rigidbody2D.velocity.y < -0.01f)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 1);
        }

        foreach(Collider2D collidingObject in collidingObjects)
        {
            if(collidingObject.TryGetComponent<IDamagable>(out IDamagable enemyInterface))
            {
                enemyInterface.Damage(_damage);
            }
        }
        StartCoroutine(hitCooldown());
    }

    private IEnumerator hitCooldown()
    {
        _canHit = false;

        yield return new WaitForSeconds(_coolDown);

        _canHit = true;
    }

    private IEnumerator StoppingInAir()
    {
        _rigidbody2D.drag = _linearStoppingDrag;

        yield return new WaitForSeconds(2f);

        _rigidbody2D.drag = 0;
    }

    private void OnDrawGizmosSelected()
    {
        if (_hitPoint == null)
            return;
        Gizmos.DrawWireSphere(_hitPoint.position, _hitPointRadius);
    }
}
