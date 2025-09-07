using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateRetreat :BaseState
{
    public void EnterState(Enemy enemy)
    {
        enemy.animator.SetTrigger("RetreatState");
    }

    public void ExitState(Enemy enemy)
    {
        
    }

    public void UpdateState(Enemy enemy)
    {
       if (enemy.player != null)
        {
            enemy.NavAgent.destination = enemy.transform.position - enemy.player.transform.position;
        }
    }
}
