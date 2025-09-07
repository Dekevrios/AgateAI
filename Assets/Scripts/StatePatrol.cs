using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatePatrol : BaseState
{
    private bool isMoving;
    private Vector3 _destination;

    public void EnterState(Enemy enemy)
    {
        Debug.Log("Enter Patrol State");
        isMoving = false;
        enemy.animator.SetTrigger("PatrolState");
    }


    public void UpdateState(Enemy enemy)
    {
        if(Vector3.Distance(enemy.player.transform.position, enemy.transform.position) < enemy.ChaseDistance)
        {
            enemy.SwitchState(enemy.chaseState);
            
        }


        if (!isMoving)
        {
            isMoving = true;
            int index = UnityEngine.Random.Range(0, enemy.Waypoitnts.Count);
            _destination = enemy.Waypoitnts[index].position;
            enemy.NavAgent.destination = _destination;
        }
        else
        {
            if (Vector3.Distance(_destination, enemy.transform.position) <= 0.5)
            {
                isMoving = false;
            }
        }
    }

    public void ExitState(Enemy enemy)
    {

    }

}
