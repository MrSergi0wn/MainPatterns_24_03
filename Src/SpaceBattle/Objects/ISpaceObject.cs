﻿using MainPatterns.SpaceBattle.Interfaces;

namespace MainPatterns.SpaceBattle.Objects;

public interface ISpaceObject : IObject
{
    void Add(IObject obj);

    T GetComponent<T>() where T : IObject;
}