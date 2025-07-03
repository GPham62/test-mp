using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Gameplay.Character
{
    public class CharacterBridge : MonoBehaviour
    {
        private readonly Dictionary<Type, ICharacterBridge> _bridgeMap = new();
        public int characterId;

        private void Awake()
        {
            RegisterBridge(this.GetComponentInBranch<CharacterStatsBridge>());
        }

        void RegisterBridge<T>(T bridge) where T : class, ICharacterBridge
        {
            _bridgeMap[typeof(T)] = bridge;
        }
    }
}