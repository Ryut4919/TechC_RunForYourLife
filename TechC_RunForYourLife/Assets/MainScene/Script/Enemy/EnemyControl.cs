using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour {
    [SerializeField]
    Transform WalkTo1;
    [SerializeField]
    Transform WalkTo2;
    
    GameObject Player;
    NavMeshAgent agent;
    Animator _animator;
    Vector3 StartPos;

    bool WalkController;
    bool ReachWalk1;
    bool ReachWalk2;

    bool FindPlayer;

    public EnemyStatus _enemyStatus;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        StartPos = transform.position;
        WalkController =false;
        _enemyStatus = EnemyStatus.Walk;
    }
	
	// Update is called once per frame
	void Update ()
    {
        switch (_enemyStatus)
        {
            case EnemyStatus.StandBy:
                break;
            case EnemyStatus.Walk:
                if (ReachWalk1)
                {
                    agent.destination = WalkTo1.position;
                }
                else if (ReachWalk2)
                {
                    agent.destination = WalkTo2.position;
                }
                WalkTo();
                break;
            case EnemyStatus.Wait:
                Wait();
                break;
            case EnemyStatus.FindPlayer:
                Find();
                break;
            case EnemyStatus.GoBack:
                GoBack();
                break;
        }
        if (FindPlayer)
        {
            WalkController = false;
            ReachWalk1 = false;
            ReachWalk2 = false;
        }
        else if (!FindPlayer)
        {
            if (WalkController)
            {
                ReachWalk1 = true;
                ReachWalk2 = false;
            }
            else if (!WalkController)
            {
                ReachWalk1 = false;
                ReachWalk2 = true;
            }
        }
        


    }

    private void WalkTo()
    {
        agent.speed = 1.5f;
        _animator.SetBool("Run", true);
        if (ReachWalk1)
        {
            if (transform.position.x==WalkTo1.position.x)
            {   
               _enemyStatus = EnemyStatus.Wait;
            }
        }
        else if (ReachWalk2)
        {
            if (transform.position.x==WalkTo2.position.x)
            {
                _enemyStatus = EnemyStatus.Wait;
            }
        }
    }


    private void Wait()
    {
        WalkController = !WalkController;
        agent.speed = 0f;
        _animator.SetBool("Run", false);
        new WaitForSeconds(60.0f);
        _enemyStatus = EnemyStatus.Walk;
    }

    private void Find()
    {
        FindPlayer = true;
        agent.speed = 3.5f;
        agent.destination = Player.transform.position;
        _animator.SetBool("Run", true);
    }

    private void GoBack()
    {
        agent.speed = 2.5f;
        agent.destination = StartPos;
        _animator.SetBool("Run", true);
        if (transform.position.x == StartPos.x)
        {
            FindPlayer = false;
            WalkController = true;
            _enemyStatus = EnemyStatus.Walk;
        }
    }

    void OnCallChangeFace()
    {

    }

    public enum EnemyStatus
    {
        StandBy,
        Walk,
        Wait,
        FindPlayer,
        GoBack
    }
}
