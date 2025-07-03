using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityVector2;
using UnityEngine.AI;
using ZBase.UnityScreenNavigator.Core.Views;

namespace Gameplay.Character
{
    [TaskCategory("Custom")]
    [TaskIcon("Assets/Clean Vector Icons/{SkinColor}T_1_sword90_.png")]
    public class AttackAction : Action
    {
        public SharedGameObject target;
        public SharedFloat speed;
        private NavMeshAgent _navMeshAgent;  
        private bool stop;

        public override void OnStart()
        {
            base.OnStart();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.SetDestination(target.Value.transform.position);
        }

        public override TaskStatus OnUpdate()
        {
            var baseStatus = base.OnUpdate();
            if (baseStatus != TaskStatus.Running)
                return baseStatus;

            if ((transform.position - target.Value.transform.position).magnitude < 1 && !stop)
            {
                stop = true;
            }
            else
            {
                stop = false;
                _navMeshAgent.SetDestination(target.Value.transform.position);
            }
            
            return base.OnUpdate();
        }
        
    }
}
