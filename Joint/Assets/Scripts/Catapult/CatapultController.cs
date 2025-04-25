using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CatapultController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private Transform _spawnBulletPoint;

    private IInputService _input;
    private CatapultState _state;
    private Rigidbody _rigidbody;

    private bool _shouldChangeToHighAnchor;
    private bool _shouldChangeToLowAnchor;

    public Action<Transform> CatapultLoaded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _input = new KeyboardInputService();
        _state = new CatapultState();
    }

    private void Start()
    {
        CatapultLoaded?.Invoke(_spawnBulletPoint);
    }

    private void FixedUpdate()
    {
        HandleAnchorChanges();
    }

    private void Update()
    {
        if (_input.IsChangeToHighAnchorPressed())
            _shouldChangeToHighAnchor = true;
        else if(_input.IsChangeToLowAnchorPressed())
            _shouldChangeToLowAnchor = true;
    }

    private void HandleAnchorChanges()
    {
        if (_shouldChangeToHighAnchor)
        {
            ChangeAnchor(_state.HighAnchor);
            _shouldChangeToHighAnchor = false;
        }
        else if (_shouldChangeToLowAnchor)
        {
            ChangeAnchor(_state.LowAnchor);
            _shouldChangeToLowAnchor = false;
            CatapultLoaded?.Invoke(_spawnBulletPoint);
        }
    }

    private void ChangeAnchor(Vector3 newAnchor)
    {
        _springJoint.connectedAnchor = newAnchor;
        _state.CurrentAnchor = newAnchor;
        _rigidbody.WakeUp();
    }
}