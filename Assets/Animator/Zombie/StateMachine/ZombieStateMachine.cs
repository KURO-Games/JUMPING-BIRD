using UnityEngine;

public class ZombieStateMachine : StateMachineBehaviour
{
    bool _once;
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime < 1.0f && !_once)
        {
            animator.SetTrigger("Once");
            _once = true;
        }

    }
}
