using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [Header("====DebugValues====")]
    [SerializeField] Vector3[] _movementVectorInput; public Vector3[] MovementVectorInput { get { return _movementVectorInput; } }


    private COconut _coconutInputs;


    public delegate void InputEvent();
    public static event InputEvent P1Jump;
    public static event InputEvent P2Jump;

    private void Awake()
    {
        _coconutInputs = new COconut();
    }

    private void Update()
    {
        Vector2 moveVector;

        moveVector = _coconutInputs.P1.Move.ReadValue<Vector2>();
        _movementVectorInput[0] = _movementVectorInput[0] = new Vector3(moveVector.x, 0f, moveVector.y);

        moveVector = _coconutInputs.P2.Move.ReadValue<Vector2>();
        _movementVectorInput[1] = _movementVectorInput[1] = new Vector3(moveVector.x, 0f, moveVector.y);

        _coconutInputs.P1.Jump.performed += ctx => P1Jump();
        _coconutInputs.P2.Jump.performed += ctx => P2Jump();
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
