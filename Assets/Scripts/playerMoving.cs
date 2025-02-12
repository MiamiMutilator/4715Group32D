using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoving : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Moving", true);
            animator.SetBool("Jumped", false);
        }
        if (Input.anyKey == false)
        {
            animator.SetBool("Moving", false);
            animator.SetBool("Jumped", false);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Jumped", true);
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}