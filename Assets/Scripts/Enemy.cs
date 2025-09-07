using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public List<Transform> Waypoitnts = new List<Transform>();
    [SerializeField]
    public float ChaseDistance;
    [SerializeField]
    public PlayerMovement player;


    private BaseState currState;

    [HideInInspector]
    public StatePatrol patrolState = new StatePatrol();
    [HideInInspector]
    public StateChase chaseState = new StateChase();
    [HideInInspector]
    public StateRetreat retreatState = new StateRetreat();
    [HideInInspector]
    public NavMeshAgent NavAgent;

    public void SwitchState(BaseState state)
    {
        currState.ExitState(this);
        currState = state;
        currState.EnterState(this);
    }

    private void Awake()
    {
        currState = patrolState;
        currState.EnterState(this);
        NavAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        if(player != null)
        {
            player.OnPowerUpStart += StartRetreating;
            player.OnPowerUpEnd += StopRetreating;
        }
    }

    private void Update()
    {
        if (currState != null)
        {
            currState.UpdateState(this);
        }
    }

    private void StartRetreating()
    {
        SwitchState(retreatState);
    }

    private void StopRetreating()
    {
        SwitchState(patrolState);
    }

}
