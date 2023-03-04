using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoconutStateMachine : MonoBehaviour
{
    [Header("====DebugVariables====")]
    private CoconutBaseState _currentState; public CoconutBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    private CoconutStateFactory _stateFactory; public CoconutStateFactory StateFactory { get { return _stateFactory; } set { _stateFactory = value; } }
    [SerializeField] string _currentStateName; public string CurrentStateName { get { return _currentStateName; } set { _currentStateName = value; } }



    [Space(20)]

    [Header("====References====")]
    [SerializeField] Rigidbody _rigidbody; public Rigidbody Rigidbody { get { return _rigidbody; } set { _rigidbody = value; } }
    [SerializeField] Transform _shovel; public Transform Shovel { get { return _shovel; } set { _shovel = value; } }
    [SerializeField] Transform _hpBar; public Transform HPBar { get { return _hpBar; } set { _hpBar = value; } }
    [SerializeField] Transform _hpBarBack; public Transform HpBarBack { get { return _hpBarBack; } set { _hpBarBack = value; } }
    [SerializeField] ParticleSystem _waterSplashParticle;


    [Space(20)]

    [Header("====OtherScripts====")]
    [SerializeField] InputController _inputController; public InputController InputController { get { return _inputController; } }
    [SerializeField] CoconutMovementController _coconutMovementController; public CoconutMovementController CoconutMovementController { get { return _coconutMovementController; } }
    [SerializeField] ShovelController _shovelController; public ShovelController ShovelController { get { return _shovelController; } set { _shovelController = value; } }
    [SerializeField] LookAtPositioner _lookAtPositioner; public LookAtPositioner LookAtPositioner { get { return _lookAtPositioner; } set { _lookAtPositioner = value; } }
    [SerializeField] CoconutRotator _coconutRotator; public CoconutRotator CoconutRotator { get { return _coconutRotator; } set { _coconutRotator = value; } }
    [SerializeField] CoconutStateMachine _otherCoconutStateMachine; public CoconutStateMachine OtherCoconutStateMachine { get { return _otherCoconutStateMachine; } set { _otherCoconutStateMachine = value; } }



    [Space(20)]

    [Header("====Settings====")]
    [SerializeField] int _coconutIndex; public int CoconutIndex { get { return _coconutIndex; } }
    [SerializeField] Vector3 _coconutPalmPosition; public Vector3 CoconutPalmPosition { get { return _coconutPalmPosition; } }
    [SerializeField] Vector3 _coconutPalmRotation; public Vector3 CoconutPalmRotation { get { return _coconutPalmRotation; } }
    [SerializeField] Vector3 _rotationTarget; public Vector3 RotationTarget { get { return _rotationTarget; } }
    [Range(0, 100)]
    [SerializeField] float _health; public float Health { get { return _health; } set { _health = value; } }


    [Space(20)]

    [Header("====Switches====")]
    [SerializeField] bool _battleSwitch; public bool BattleSwitch { get { return _battleSwitch; } set { _battleSwitch = value; } }
    [SerializeField] bool _fallSwitch; public bool FallSwitch { get { return _fallSwitch; } set { _fallSwitch = value; } }
    [SerializeField] bool _isGameOver; public bool IsGameOver { get { return _isGameOver; } set { _isGameOver = value; } }

    private bool _winner; public bool Winner { get { return _winner; } set { _winner = value; } }


    private void Awake()
    {
        _stateFactory = new CoconutStateFactory(this);
        _currentState = _stateFactory.PalmState();
        _currentState.EnterState();
    }
    private void Start()
    {
        _winner = true;
        _rigidbody.freezeRotation = true;
    }

    private void Update()
    {
        _currentState.UpdateState();
        _currentState.CheckStateChange();
    }
    private void FixedUpdate()
    {
        _currentState.FixedUpdateState();
    }



    public void TakeDamage()
    {
        if (_isGameOver) return;

        _health -= 20;

        float healthBarTargetScaleX = ((_health / 100) * 2);
        Debug.Log(healthBarTargetScaleX);

        _hpBar.LeanScaleX(healthBarTargetScaleX, 0.2f);

        if(_health <= 0)
        {
            _winner = false;
            _isGameOver = true;
        }
    }


    private void StartGame()
    {
        _fallSwitch = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Water")) return;

        Instantiate(_waterSplashParticle, transform.position, Quaternion.identity);

        if(_currentStateName == "Battle")
        {
            _winner = false;
            _isGameOver = true;

            _otherCoconutStateMachine.Winner = true;
            _otherCoconutStateMachine.IsGameOver = true;
        }
        else if (_currentStateName == "GameOver")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnEnable()
    {
        CanvasController.StartGame += StartGame;
    }
    private void OnDisable()
    {
        CanvasController.StartGame -= StartGame;
    }
}
