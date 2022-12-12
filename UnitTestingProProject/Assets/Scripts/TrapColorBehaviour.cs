using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapColorBehaviour : MonoBehaviour
{
    [SerializeField]
    private ColorTrapTargetType colorTrapType;

    private ColorTrap colorTrap;

    private void Awake()
    {
        colorTrap = new ColorTrap();
    }
    private void OnTriggerEnter(Collider other)
    {
        var characterMover = other.GetComponent<ICharacterMover>();
        colorTrap.HandleCharacterEntered(characterMover, colorTrapType);
    }
}

public class ColorTrap
{
    public void HandleCharacterEntered(ICharacterMover characterMover, ColorTrapTargetType sizeTrapTargetType)
    {
        if (characterMover.IsPlayer)
        {
            if (sizeTrapTargetType == ColorTrapTargetType.Player)
                characterMover.Color = 1;
        }
        else
        {
            if (sizeTrapTargetType == ColorTrapTargetType.Npc)
                characterMover.Color = 2;
        }
    }
}

public enum ColorTrapTargetType { Player, Npc }
