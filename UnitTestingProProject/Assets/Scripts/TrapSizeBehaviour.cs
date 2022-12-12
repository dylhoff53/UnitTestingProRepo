using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSizeBehaviour : MonoBehaviour
{
    [SerializeField]
    private SizeTrapTargetType sizeTrapType;

    private SizeTrap sizeTrap;

    private void Awake()
    {
        sizeTrap = new SizeTrap();
    }
    private void OnTriggerEnter(Collider other)
    {
        var characterMover = other.GetComponent<ICharacterMover>();
        sizeTrap.HandleCharacterEntered(characterMover, sizeTrapType);
    }
}

public class SizeTrap
{
    public void HandleCharacterEntered(ICharacterMover characterMover, SizeTrapTargetType sizeTrapTargetType)
    {
        if (characterMover.IsPlayer)
        {
            if (sizeTrapTargetType == SizeTrapTargetType.Player)
                characterMover.Size = 0.5f;
        }
        else
        {
            if (sizeTrapTargetType == SizeTrapTargetType.Npc)
                characterMover.Size = 0.25f;
        }
    }
}

public enum SizeTrapTargetType { Player, Npc }

