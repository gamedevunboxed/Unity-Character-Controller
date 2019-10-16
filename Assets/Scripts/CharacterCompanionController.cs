using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCompanionController : MonoBehaviour
{
    [SerializeField]
    private Character _leadCharacter;

    [SerializeField]
    private float _followDistance = 5.0f;

    [SerializeField]
    private Character _controlledCharacter;

    public Character ControlledCharacter { get { return _controlledCharacter; } set { _controlledCharacter = value; } }

    public Character LeadCharacter { get { return _leadCharacter; } set { _leadCharacter = value; } }

    private void Start()
    {
        ControlledCharacter = _controlledCharacter;
        ControlledCharacter.transform.position = _leadCharacter.transform.position - (_leadCharacter.transform.right * _followDistance);
    }

    private void Update()
    {
        if(IsTooFarFromLeadCharacter(ControlledCharacter.transform.position,_leadCharacter.transform.position,_followDistance))
        {
            if(_leadCharacter.transform.right == Vector3.right)
            {
                ControlledCharacter.WalkRight();
            }
            else if(_leadCharacter.transform.right == Vector3.left)
            {
                ControlledCharacter.WalkLeft();
            }
        }
        else
        {
            ControlledCharacter.StopWalkingAnimation();
        }
    }

    private bool IsTooFarFromLeadCharacter(Vector3 characterPosition, Vector3 leadCharacterPosition, float followDistance)
    {
        var distance = Vector3.Distance(characterPosition, leadCharacterPosition);

        if (distance > followDistance)
        {
            return true;
        }

        return false;
    }
}
