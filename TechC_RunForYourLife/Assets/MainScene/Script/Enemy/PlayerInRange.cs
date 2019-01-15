using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRange : MonoBehaviour {
    [SerializeField]
    private EnemyControl parent;

    [SerializeField]
    private bool FindUse;
    [SerializeField]
    private bool CaughtUse;
	// Use this for initialization
	
    private void OnTriggerEnter(Collider other)
    {
        if (FindUse)
        {
            if (other.tag == "Player")
            {
                parent._enemyStatus = EnemyControl.EnemyStatus.GoCaughtPlayer;
            }
        }
        if (CaughtUse)
        {
            if (other.tag == "Player")
            {
                //   parent._enemyStatus = EnemyControl.EnemyStatus.FindPlayer;
                Debug.Log("GoddGameWillPlay");
            }
        }
        
    }
}
