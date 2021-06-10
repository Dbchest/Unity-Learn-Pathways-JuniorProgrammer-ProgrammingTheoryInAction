using UnityEngine;

public class PanelIdleStateMachine : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        var f = animator.GetFloat("Initial Speed Multiplier");
        animator.SetFloat("Speed Multiplier", f);
    }
}