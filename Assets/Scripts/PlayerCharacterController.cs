using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField]
    private Character _controlledCharacter;

    public Character ControlledCharacter { get { return _controlledCharacter; } set { _controlledCharacter = value; } }

    private void Start()
    {
        ControlledCharacter = _controlledCharacter;
    }

    private void Update()
    {
        var horizontalMovement = Input.GetAxis("Horizontal");

        if(horizontalMovement > 0)
        {
            ControlledCharacter.WalkRight();
        }
        else if(horizontalMovement < 0)
        {
            ControlledCharacter.WalkLeft();
        }
        else
        {
            ControlledCharacter.StopWalkingAnimation();
        }

        if(Input.GetButtonDown("Jump"))
        {
            ControlledCharacter.Jump();
        }
    }
}
