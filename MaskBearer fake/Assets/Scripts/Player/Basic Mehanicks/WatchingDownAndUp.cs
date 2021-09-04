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
    private LookingDown _lookingDown;

    public bool isDashing;

    private void OnEnable()
    {
        _animator = GetComponentInParent<Animator>();

        _lookingDown = LookingDown.Standart;

        _standartPos = transform.localPosition;

        inputActions = new Player();
        inputActions.Enable();

        inputActions.PlayerInput.LookUp.performed += ctx => StartCoroutine(LookUp());
        inputActions.PlayerInput.LookUp.canceled += ctx => ResetCamPos();

        inputActions.PlayerInput.LookDown.performed += ctx => StartCoroutine(LookDown());
        inputActions.PlayerInput.LookDown.canceled += ctx => ResetCamPos();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public IEnumerator LookUp()
    {
        if (_animator.GetBool("isRunning") || isDashing)
            yield break;

        _lookingDown = LookingDown.Up;

        yield return new WaitForSeconds(_lookingCooldown);

        if (_lookingDown != LookingDown.Up)
            yield break;

        if (_animator.GetBool("isRunning") || isDashing)
            yield break;

        if (_animator.GetBool("watchDown"))
            yield break;

        _animator.SetBool("watchUp", true);
        _animator.SetTrigger("Watch Up");

        transform.position = _targetUp.position;
    }

    public IEnumerator LookDown()
    {
        if (_animator.GetBool("isRunning") || isDashing)
            yield break;

        _lookingDown = LookingDown.Down;

        yield return new WaitForSeconds(_lookingCooldown);

        if (_lookingDown != LookingDown.Down)
            yield break;

        if (_animator.GetBool("watchUp"))
            yield break;

        _animator.SetBool("watchDown", true);
        _animator.SetTrigger("Watch Down");

        transform.position = _targetDown.position;
    }

    public void ResetCamPos()
    {
        _lookingDown = LookingDown.Standart;

        _animator.SetBool("watchDown", false);
        _animator.SetBool("watchUp", false);

        transform.localPosition = _standartPos; 
    }

}
public enum LookingDown
{
    Up, Down, Standart
}
