using UnityEngine;

public class CharacterAnimationBridge : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void MoveAnim(float magnitude)
    {
        animator.SetBool("Moving", true);
        animator.SetFloat("Velocity Z", magnitude);
    }

    public void StopMoveAnim()
    {
        animator.SetBool("Moving", false);
        animator.SetFloat("Velocity Z", 0);
    }

    public void AttackAnim()
    {
        animator.SetInteger("Action", 1);
        animator.SetInteger("TriggerNumber", 4);
        animator.SetTrigger("Trigger");
    }
}
