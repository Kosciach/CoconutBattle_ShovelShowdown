using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class CoconutMovementController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] InputController _inputController;
    [SerializeField] Transform _groundCheckTransform;
    [SerializeField] ParticleSystem _groundParticle;

    [Space(20)]

    [Header("====Settings====")]
    [Range(0, 10f)]
    [SerializeField] float _movementSpeed;
    [Range(0, 10f)]
    [SerializeField] float _acceleriationSpeed;
    [Range(0, 10f)]
    [SerializeField] float _jumpForce;
    [Range(0, 1f)]
    [SerializeField] float _groundCheckRadius;

    [Space(10)]

    [SerializeField] int _playerIndex;
    [SerializeField] LayerMask _groundMask;


    [Space(20)]


    [Header("====DebugValues====")]
    [SerializeField] bool _isGrounded; public bool IsGrounded { get { return _isGrounded; } }
    [SerializeField] bool _isInBattle; public bool IsInBattle { get { return _isInBattle; } set { _isInBattle = value; } }

    private Vector3 _smoothMoveVector;



    private void Update()
    {
        CheckGrounded();
    }



    public void Movement()
    {
        _smoothMoveVector = Vector3.Lerp(_smoothMoveVector, _inputController.MovementVectorInput[_playerIndex], _acceleriationSpeed * Time.deltaTime);

        if (_inputController.MovementVectorInput[_playerIndex].magnitude > 0 && _isGrounded) Instantiate(_groundParticle, _groundCheckTransform.position, Quaternion.identity);

        Vector3 movementVector = _smoothMoveVector * _movementSpeed;
        Vector3 correctedMovementVector = new Vector3(movementVector.x, _rigidbody.velocity.y, movementVector.z);

        _rigidbody.velocity = correctedMovementVector;
    }

    private void CheckGrounded()
    {
        _isGrounded = Physics.CheckSphere(_groundCheckTransform.position, _groundCheckRadius, _groundMask);
    }

    private void P1Jump()
    {
        if (!_isGrounded || !_isInBattle) return;
        if (_playerIndex == 0)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
    private void P2Jump()
    {
        if (!_isGrounded || !_isInBattle) return;
        if (_playerIndex == 1)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }


    private void OnEnable()
    {
        InputController.P1Jump += P1Jump;
        InputController.P2Jump += P2Jump;
    }
    private void OnDisable()
    {
        InputController.P1Jump -= P1Jump;
        InputController.P2Jump -= P2Jump;
    }
}
