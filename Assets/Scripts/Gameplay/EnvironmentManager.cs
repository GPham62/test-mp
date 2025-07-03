using UnityEngine;

namespace Gameplay
{
    public class EnvironmentManager : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPosArr;

        public Vector3 GetSpawnablePosition()
        {
            return Vector3.zero;
        }
    }
}
