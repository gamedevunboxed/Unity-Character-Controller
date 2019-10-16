using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;

    private Animator _animator;

    private bool _isJumping;

    private float _jumpHeight;

    public void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");

        _animator.SetFloat("WalkingRight", horizontal);
        _animator.SetFloat("WalkingLeft", horizontal);
        transform.Translate(Vector3.right * horizontal * _speed * Time.deltaTime);

        if(_isJumping)
        {
            if(transform.position.y < _jumpHeight)
            {
                Vector3 newPosition = transform.position;
                newPosition.y += Time.deltaTime;
                transform.position = newPosition;
            }
        }

    }

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * _speed);
    }

    public void Jump(float height)
    {
        _isJumping = true;
        _jumpHeight = transform.position.y + height;
    }
}
