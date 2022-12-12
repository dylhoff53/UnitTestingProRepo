using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using NSubstitute;

public class TrapTests
{
    [Test]
    public void PlayerEntering_PlayerTargetedTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        ICharacterMover characterMover = Substitute.For<ICharacterMover>();
        characterMover.IsPlayer.Returns(true);

        trap.HandleCharacterEntered(characterMover, TrapTargetType.Player);

        Assert.AreEqual(-1, characterMover.Health);
    }

    [Test]
    public void NPCEntering_NpcTargetedTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        ICharacterMover characterMover = Substitute.For<CharacterMover>();
        trap.HandleCharacterEntered(characterMover, TrapTargetType.Npc);
        Assert.AreEqual(-1, characterMover.Health);

    }

    [Test]
    public void PlayerEntering_PlayerSizeTargetedTrap_ReducesHealthByOne()
    {
        SizeTrap sizeTrap = new SizeTrap();
        ICharacterMover characterMover = Substitute.For<ICharacterMover>();
        characterMover.IsPlayer.Returns(true);

        sizeTrap.HandleCharacterEntered(characterMover, SizeTrapTargetType.Player);

        Assert.AreEqual(0.5f, characterMover.Size);
    }

    [Test]
    public void NPCEntering_NpcSizeTargetedTrap_ReducesHealthByOne()
    {
        SizeTrap sizeTrap = new SizeTrap();
        ICharacterMover characterMover = Substitute.For<CharacterMover>();
        sizeTrap.HandleCharacterEntered(characterMover, SizeTrapTargetType.Npc);
        Assert.AreEqual(0.25f, characterMover.Size);

    }

    [Test]
    public void PlayerEntering_PlayerColorTargetedTrap_ReducesHealthByOne()
    {
        ColorTrap colorTrap = new ColorTrap();
        ICharacterMover characterMover = Substitute.For<ICharacterMover>();
        characterMover.IsPlayer.Returns(true);

        colorTrap.HandleCharacterEntered(characterMover, ColorTrapTargetType.Player);

        Assert.AreEqual(1, characterMover.Color);
    }

    [Test]
    public void NPCEntering_NpcColorTargetedTrap_ReducesHealthByOne()
    {
        ColorTrap colorTrap = new ColorTrap();
        ICharacterMover characterMover = Substitute.For<CharacterMover>();
        colorTrap.HandleCharacterEntered(characterMover, ColorTrapTargetType.Npc);
        Assert.AreEqual(2, characterMover.Color);

    }
}
