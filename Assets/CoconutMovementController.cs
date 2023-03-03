using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutMovementController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] InputController _inputController;

    [Header("====Settings====")]
    [Range(0, 10f)]
    [SerializeField] float _movementSpeed;
    [Range(0, 10f)]
    [SerializeField] float _acceleriationSpeed;
    [SerializeField] int _playerIndex;


    private Vector3 _smoothMoveVector;

    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        _smoothMoveVector = Vector3.Lerp(_smoothMoveVector, _inputController.MovementVectorInput[_playerIndex], _acceleriationSpeed * Time.deltaTime);

        Vector3 movementVector = _smoothMoveVector * _movementSpeed;
        Vector3 correctedMovementVector = new Vector3(movementVector.x, _rigidbody.velocity.y, movementVector.z);

        _rigidbody.velocity = correctedMovementVector;
    }
}
