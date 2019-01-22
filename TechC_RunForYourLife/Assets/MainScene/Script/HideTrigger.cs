using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTrigger : MonoBehaviour {

    [SerializeField]
    EnemyControl _enemyControl;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        _enemyControl._enemyStatus = EnemyControl.EnemyStatus.GoCaughtPlayer;
    }
}
