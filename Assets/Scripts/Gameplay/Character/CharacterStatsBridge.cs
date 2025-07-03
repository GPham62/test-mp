using UnityEngine;

namespace Gameplay.Character
{
    public class CharacterStatsBridge : MonoBehaviour, ICharacterBridge
    {
        [SerializeField] private CharacterStatSO constantStats;
        
        protected CharacterBridge CharacterBridge;
        
        public void SetCharacterBridge(CharacterBridge characterBridge)
        {
            CharacterBridge = characterBridge;
        }
    }
}
