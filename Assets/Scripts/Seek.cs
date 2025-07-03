using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI;

[TaskDescription("Returns a TaskStatus of running. Will only stop when interrupted or a conditional abort is triggered.")]
[TaskIcon("{SkinColor}IdleIcon.png")]
public class Seek : Action
{
    public SharedFloat speed;
    public SharedFloat angularSpeed;
    public SharedGameObject target;
    public SharedVector3 targetPosition;
    private NavMeshAgent _navMeshAgent;
    public float arriveDistance;
    public override void OnStart()
    {
        _navMeshAgent.speed = speed.Value;
        _navMeshAgent.angularSpeed = angularSpeed.Value;
        _navMeshAgent.isStopped = false;
        SetDestination(Target());
        base.OnStart();
    }

    private bool SetDestination(Vector3 target)
    {
        _navMeshAgent.isStopped = false;
        return _navMeshAgent.SetDestination(target);
    }

    private Vector3 Target()
    {
        if (target.Value != null)
        {
            return target.Value.transform.position;
        }

        return targetPosition.Value;
    }

    public override TaskStatus OnUpdate()
    {
        if (HasArrived())
        {
            return TaskStatus.Success;
        }
        SetDestination(Target());
        return TaskStatus.Running;
    }

    private bool HasArrived()
    {
        return false;
    }
}
