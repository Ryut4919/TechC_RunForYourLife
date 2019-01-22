using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour {
    
    //往復ポイント1
    [SerializeField]
    Transform WalkTo1;
    ////往復ポイント2
    [SerializeField]
    Transform WalkTo2;

    //プレーヤーを探す時のコライダー
    [SerializeField]
    GameObject FindPlayerUse;

    //プレーヤーを追い詰める時のコライダー
    [SerializeField]
    GameObject CaughtPlayerUse;

    //プレーヤーを取得
    GameObject Player;
    
    NavMeshAgent agent;
    Animator _animator;
    //最初の場所を取得
    Vector3 StartPos;

    bool WalkController;
    bool ReachWalk1;
    bool ReachWalk2;
    bool CaughtPlayer;

    //今の状態
    public EnemyStatus _enemyStatus;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        StartPos = transform.position;
        WalkController =false;
       // _enemyStatus = EnemyStatus.Walk;
    }
	
	// Update is called once per frame
	void Update ()
    {
        switch (_enemyStatus)
        {
            case EnemyStatus.StandBy://そのまま立つ

                break;
            case EnemyStatus.Walk://往復移動する
                if (ReachWalk1)
                {
                    //移動先を変更
                    agent.destination = WalkTo1.position;
                }
                else if (ReachWalk2)
                {
                    //移動先を変更
                    agent.destination = WalkTo2.position;
                }
                WalkTo();
                break;
            case EnemyStatus.Wait://少しい待ちます
                Wait();
                break;
            case EnemyStatus.GoCaughtPlayer://プレーヤーを追い
                Find();
                break;
            case EnemyStatus.GoBack://最初の場所へ戻す
                GoBack();
                break;
            case EnemyStatus.GameFinish:
                StopMove();
                break;
        }
        if (CaughtPlayer)
        {
            WalkController = false;
            ReachWalk1 = false;
            ReachWalk2 = false;

            FindPlayerUse.SetActive(false);
            CaughtPlayerUse.SetActive(true);

        }
        else if (!CaughtPlayer)
        {
            FindPlayerUse.SetActive(true);
            CaughtPlayerUse.SetActive(false);
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

    private void StopMove()
    {
        _animator.SetBool("Run", false);
        agent.speed = 0.0f;
        
    }

    private void WalkTo()
    {
        //移動スピード
        agent.speed = 2.5f;
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
        agent.speed = 1f;
        _animator.SetBool("Run", false);
        new WaitForSeconds(60.0f);
        _enemyStatus = EnemyStatus.Walk;
    }

    private void Find()
    {

        CaughtPlayer = true;
        agent.speed = 4.5f;
        //移動先をプレーヤーのところに変更
        agent.destination = Player.transform.position;
        _animator.SetBool("Run", true);
    }

    private void GoBack()
    {
        agent.speed = 3.5f;
        //移動先を最初の場所へ変更
        agent.destination = StartPos;
        _animator.SetBool("Run", true);
        CaughtPlayer = false;

        if (transform.position.x == StartPos.x)
        {
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
        GoCaughtPlayer,
        GoBack,
        GameFinish
    }
}
