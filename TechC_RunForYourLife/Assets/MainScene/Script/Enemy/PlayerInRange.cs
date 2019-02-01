using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRange : MonoBehaviour {
    [SerializeField]
    private EnemyControl parent;
    [SerializeField]
    Manager _gameManager;

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
                other.GetComponent<CharacterControl>().Deteched = true;
            }
        }
        if (CaughtUse)
        {
            if (other.tag == "Player")
            {
                //   parent._enemyStatus = EnemyControl.EnemyStatus.FindPlayer;
                _gameManager.GameFinish = true;
                Debug.Log("GoodGameWillPlay");
            }
        }
        
    }
}
