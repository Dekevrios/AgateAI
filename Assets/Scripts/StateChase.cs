using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateChase : BaseState
{
    public void EnterState(Enemy enemy)
    {
        
    }

    public void UpdateState(Enemy enemy)
    {
        if (enemy.player != null)
        {
            enemy.NavAgent.destination = enemy.player.transform.position;
            if (Vector3.Distance(enemy.player.transform.position, enemy.transform.position) > enemy.ChaseDistance)
            {
                enemy.SwitchState(enemy.patrolState);
            }
        }
    }
    public void ExitState(Enemy enemy)
    {

    }

   
}
