﻿using System.Numerics;
using SpaceBattle.Components.Calculations;

namespace SpaceBattle.Components.Actions
{
    public interface IRotatable
    {
        public int Direction { get; set; }

        public int AngularVelocity { get; }
    }
}
