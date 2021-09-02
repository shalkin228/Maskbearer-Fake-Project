using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchingDownAndUp : MonoBehaviour
{
    [SerializeField] private Transform _targetUp, _targetDown;
    [SerializeField] private float _lookingCooldown;
    private Vector2 _standartPos;
    private Player inputActions;
    private Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponentInParent<Animator>();

        _standartPos = transform.localPosition;

        inputActions = new Player();
        inputActions.Enable();

        inputActions.PlayerInput.LookUp.performed += ctx => StartCoroutine(LookUp());
        inputActions.PlayerInput.LookUp.canceled += ctx => LookUpStop();

        inputActions.PlayerInput.LookDown.performed += ctx => StartCoroutine(LookDown());
        inputActions.PlayerInput.LookDown.canceled += ctx => LookDownStop();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public IEnumerator LookUp()
    {
        if (_animator.GetBool("isRunning"))
            yield break;

        _animator.SetBool("watchUp", true);
        _animator.SetTrigger("Watch Up");

        yield return new WaitForSeconds(_lookingCooldown);

        if (!_animator.GetBool("watchUp"))
            yield break;

        transform.position = _targetUp.position;
    }

    public void LookUpStop()
    {
        _animator.SetBool("watchUp", false);

        transform.localPosition = _standartPos;
    }

    public IEnumerator LookDown()
    {
        if (_animator.GetBool("isRunning"))
            yield break;

        _animator.SetBool("watchDown", true);
        _animator.SetTrigger("Watch Down");

        yield return new WaitForSeconds(_lookingCooldown);

        if (!_animator.GetBool("watchDown"))
            yield break;

        transform.position = _targetDown.position;
    }

    public void LookDownStop()
    {
        transform.localPosition = _standartPos;

        _animator.SetBool("watchDown", false);
    }

    public void ResetCamPos()
    {
        transform.localPosition = _standartPos; 
    }

}
