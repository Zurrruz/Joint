using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class SwingController : MonoBehaviour
{
    [SerializeField] private float _swingForce = 100f;

    private HingeJoint _hinge;
    private IInputService _input;

    private bool _isChangeRockingPressed;

    private void Awake()
    {
        _hinge = GetComponent<HingeJoint>();
        _input = new KeyboardInputService();
    }

    private void FixedUpdate()
    {
        if (_isChangeRockingPressed)
        {
            JointMotor motor = _hinge.motor;
            motor.targetVelocity = _swingForce;
            motor.force = 100f;
            _hinge.motor = motor;
            _hinge.useMotor = true;
            _isChangeRockingPressed = false;
        }
        else
        {
            _hinge.useMotor = false;
        }
    }

    private void Update()
    {
        if(_input.IsRockingPressed()) 
            _isChangeRockingPressed = true;
    }
}
