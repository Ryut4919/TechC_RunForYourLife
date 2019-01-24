﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Manager : MonoBehaviour {

    [SerializeField]
    private GameObject Enemy1;
    [SerializeField]
    private GameObject Enemy2;
    [SerializeField]
    private GameObject Enemy3;

    [SerializeField]
    private string FScene;
    [SerializeField]
    private string CScene;

    public bool GameFinish = false;
    public bool GameClear = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameFinish||GameClear)
        {
            GameF();
            if (GameFinish)
            {
                EditorSceneManager.LoadScene(FScene);
            }
            else if (GameClear)
            {
                EditorSceneManager.LoadScene(CScene); 
            }
        }
    }

    private void GameF()
    {
            Enemy1.GetComponent<EnemyControl>()._enemyStatus = EnemyControl.EnemyStatus.GameFinish;
            Enemy2.GetComponent<EnemyControl>()._enemyStatus = EnemyControl.EnemyStatus.GameFinish;
            Enemy3.GetComponent<EnemyControl>()._enemyStatus = EnemyControl.EnemyStatus.GameFinish;
    }

    	
}
