using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelController : MonoBehaviour
{
    [SerializeField] Animator _shovelAnimator;
    [SerializeField] CoconutStateMachine OtherCoconutStateMachine;
    [SerializeField] CoconutStateMachine CoconutStateMachine;
    [SerializeField] TrailRenderer _trailRenderer;
    [SerializeField] int _shovelIndex;
    [SerializeField] string _playerTag;

    private bool _isSwing;
    private bool _wasHit;
    private COconut _coconutInputs;


    private void Awake()
    {
        _coconutInputs = new COconut();
    }
    private void Start()
    {
        _isSwing = false;
        _wasHit = false;

        if (_shovelIndex == 0) _coconutInputs.P1.Attack.performed += ctx => { _shovelAnimator.SetBool("Attack", true); };
        else if (_shovelIndex == 1) _coconutInputs.P2.Attack.performed += ctx => { _shovelAnimator.SetBool("Attack", true); };
    }


    public void EnableTrail()
    {
        _trailRenderer.enabled = true;
    }
    public void DisableTrail()
    {
        _trailRenderer.enabled = false;
    }
    public void EnableSwing()
    {
        _isSwing = true;
    }
    public void DisableSwing()
    {
        _isSwing = false;
    }
    public void ResetHit()
    {
        _wasHit = false;
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerTag) && _isSwing && !_wasHit)
        {
            OtherCoconutStateMachine.TakeDamage();
            ShakeScript.Instance.Shake(2, 2);
            if (OtherCoconutStateMachine.Health <= 0)
            {
                CoconutStateMachine.Winner = true;
                CoconutStateMachine.IsGameOver = true;
            }
            _wasHit = true;
        }
    }

    private void OnEnable()
    {
        _coconutInputs.Enable();
    }
    private void OnDisable()
    {
        _coconutInputs.Disable();
    }
}
