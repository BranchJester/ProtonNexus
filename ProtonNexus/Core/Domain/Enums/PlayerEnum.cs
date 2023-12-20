﻿using System.ComponentModel;

namespace ProtonNexus.Core.Domain.Enums;

public enum PlayerEnum
{
    [Description("Restore player health, armor and special ability.")]
    FixPlayer,

    [Description("Adjust wanted level.")] WantedLevel,

    [Description("Lock wanted level at a desired level.")]
    LockWantedLevel,

    [Description("Become invincible.")] Invincible,

    [Description("Never run out of stamina.")]
    InfiniteStamina,

    [Description("Jump higher than a building.")]
    SuperJump,

    [Description("Select a desired super-speed value.")]
    SuperRun,

    [Description("You can no longer drown in water.")]
    InfiniteBreath,

    [Description("Become one-punch man and punch entities into oblivion.")]
    SuperPunch,

    [Description("Use your special ability infinitely.")]
    InfiniteSpecialAbility
}

public enum PlayerSuperSpeedEnum
{
    [Description("Runs at a normal speed.")]
    Normal,

    [Description("Runs at a fast speed.")] Fast,

    [Description("Runs at a much faster speed.")]
    Faster,

    [Description("Runs at the speed of sound! Also knocks back entities.")]
    Sonic,

    [Description("Runs at the speed of light! Also knocks back entities.")]
    Flash
}