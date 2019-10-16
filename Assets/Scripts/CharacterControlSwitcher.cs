using UnityEngine;
using UnityEngine.UI;

public class CharacterControlSwitcher : MonoBehaviour
{
    [SerializeField]
    private Character _character1;

    [SerializeField]
    private Character _character2;

    [SerializeField]
    private Text _character1NameLabel;

    [SerializeField]
    private Text _character2NameLabel;

    [SerializeField]
    private PlayerCharacterController _playerController;

    [SerializeField]
    private CharacterCompanionController _companionController;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Character newplayerCharacter             = _companionController.ControlledCharacter;
            Character newCompanionCharacter          = _playerController.ControlledCharacter;

            Text newPlayerLabel                      = _character2NameLabel;
            Text newCompanionLabel                   = _character1NameLabel;

            _playerController.ControlledCharacter    = newplayerCharacter;
            _companionController.ControlledCharacter = newCompanionCharacter;

            newCompanionCharacter.transform.parent   = _companionController.transform;
            newplayerCharacter.transform.parent      = _playerController.transform;
                                                     
            _companionController.LeadCharacter       = newplayerCharacter;

            newPlayerLabel.text        = "Player";
            newCompanionLabel.text     = "AI Companion";

            newPlayerLabel.transform.parent.GetComponent<FollowPosition>().Target    = newplayerCharacter.transform;
            newCompanionLabel.transform.parent.GetComponent<FollowPosition>().Target = newCompanionCharacter.transform;
        }
    }
}
