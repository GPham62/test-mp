using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "CharacterStatSO", menuName = "Scriptable Objects/CharacterStatSO")]
    public class CharacterStatSO : ScriptableObject
    {
        public float attack;
        public float maxHealth;
        public float attackRange;
    }
}
