﻿using System.Collections.Concurrent;
using SpaceBattle.Commands;
using SpaceBattle.IocContainer;

namespace SpaceBattle.Commands.Simple
{
    public class ScopeRegisterCommand : ICommand
    {
        private readonly ConcurrentDictionary<string, Scope> scopesCollection;
        private readonly string scopeName;

        public ScopeRegisterCommand(ConcurrentDictionary<string, Scope> scopesCollection, string scopeName)
        {
            this.scopesCollection = scopesCollection;
            this.scopeName = scopeName;
        }

        public void Execute()
        {
            if (!scopesCollection.TryAdd(scopeName, new Scope(scopeName)))
            {
                throw new Exception($"Scope {scopeName} already registered");
            }
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}