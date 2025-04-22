using UnityEngine;

public class IdleFox : StateMachineBehaviour
{
    float time;
    Transform player;    
    float chaseRange = 25;   

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;        
    }    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time += Time.deltaTime;
        if(time > 5)
        {
            animator.SetBool("isPatrolling", true);
        }
        float distance = Vector3.Distance(animator.transform.position, player.transform.position); //Player
        if(distance < chaseRange)
        {
            animator.SetBool("isChasing", true);
        }        
    }    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }   
}
