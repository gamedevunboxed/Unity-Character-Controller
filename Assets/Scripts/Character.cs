using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    private enum JumpStates
    {
        None,
        Rising,
        Falling
    }

    private JumpStates _currentState = JumpStates.None;

    private Animator _animator;

    private bool _allowedToJump;

    private float _maxJumpHeight;

    private float _jumpSpeed;

    private float _startYPosition;

    private bool _isFalling;

    private Vector3 _jumpDirection = Vector3.up;

    [SerializeField]
    private float _walkSpeed = 3.0f;

    [SerializeField]
    private float _jumpHeight = 1.0f;

    [SerializeField]
    private float _jumpTime = 1.0f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if (!_allowedToJump)
            return;

        SetJumpState(ref _currentState, transform.position.y, _maxJumpHeight);

        var newPosition = _jumpDirection * _jumpSpeed * Time.deltaTime;

        transform.Translate(newPosition);
    }

    public void WalkRight()
    {
        _animator.SetFloat("WalkingRight", _walkSpeed);
        transform.Translate(transform.right * _walkSpeed * Time.deltaTime);
    }

    public void WalkLeft()
    {
        _animator.SetFloat("WalkingLeft",   -_walkSpeed);
        transform.Translate(transform.right * -_walkSpeed * Time.deltaTime);
    }

    public void StopWalkingAnimation()
    {
        _animator.SetFloat("WalkingLeft", 0);
        _animator.SetFloat("WalkingRight", 0);
    }

    public void Jump()
    {
        if (!_allowedToJump)
        {
            _startYPosition = transform.position.y;
            // Speed = distance / time so _jumpHeight / _jumpTime gives us speed we need to move character
            // Multiply by 2 as the character also has to come back down.
            _jumpSpeed = (_jumpHeight / _jumpTime) * 2;
            _allowedToJump = true;
            _maxJumpHeight = transform.position.y + _jumpHeight;
        }
    }

    private void SetJumpState(ref JumpStates currentState, float yPosition, float jumpHeight)
    {
        if (transform.position.y > _maxJumpHeight && currentState == JumpStates.Rising)
        {
            currentState = JumpStates.Falling;
            _jumpDirection *= -1;
        }
        else if (transform.position.y <= _startYPosition && currentState == JumpStates.Falling)
        {
            currentState = JumpStates.None;
            _jumpDirection *= -1;
            _allowedToJump = false;
        }
        else if(currentState == JumpStates.None)
        {
            currentState = JumpStates.Rising;
        }
    }
}
