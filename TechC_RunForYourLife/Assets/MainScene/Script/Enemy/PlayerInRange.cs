using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRange : MonoBehaviour {
    [SerializeField]
    private EnemyControl parent;
	// Use this for initialization
	
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            parent._enemyStatus = EnemyControl.EnemyStatus.FindPlayer;
        }
    }
}
