using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    GameObject Panel01;
    [SerializeField]
    GameObject Panel02;

    [SerializeField]
    CharacterControl _charaCon;

    public bool GameStart = false;
    public bool GameFinish = false;
    public bool GameClear = false;

    private bool OnPanel01 = false;
    private bool OnPanel02=false;

    // Use this for initialization
    void Start ()
    {
       // Debug.Log(Panel01.transform.position);
        iTween.MoveTo(Panel01,new Vector3(523,427,0),2f);
        OnPanel01 = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameFinish||GameClear)
        {
            GameF();
            if (GameFinish)
            {
                SceneManager.LoadScene(FScene);
            }
            else if (GameClear)
            {
                SceneManager.LoadScene(CScene);
            }
        }

        ExplanControll();
    }

    private void GameF()
    {
            Enemy1.GetComponent<EnemyControl>()._enemyStatus = EnemyControl.EnemyStatus.GameFinish;
            Enemy2.GetComponent<EnemyControl>()._enemyStatus = EnemyControl.EnemyStatus.GameFinish;
            Enemy3.GetComponent<EnemyControl>()._enemyStatus = EnemyControl.EnemyStatus.GameFinish;
    }

    private void ExplanControll()
    {
        if (OnPanel01 && Input.GetKeyDown(KeyCode.F)||OnPanel01&&Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            iTween.MoveTo(Panel01, new Vector3(1717, 427, 0), 2f);
            OnPanel01 = false;
            iTween.MoveTo(Panel02, new Vector3(523, 427, 0), 3f);
            OnPanel02 = true;
        }
       else  if (OnPanel02 && Input.GetKeyDown(KeyCode.F) || OnPanel02 && Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            iTween.MoveTo(Panel02, new Vector3(1717, 427, 0), 2f);
            GameStart = true;
        }
    }

    	
}
