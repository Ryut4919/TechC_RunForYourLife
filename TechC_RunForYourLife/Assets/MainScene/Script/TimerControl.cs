using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour {
    [SerializeField]
    Manager _gameManage;
    [SerializeField]
    Text _timerText;

    private float StartTime = 60.0f;
    private float Countertimer;

	// Use this for initialization
	void Start ()
    {
        //_timerText.text = StartTime.ToString();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (_gameManage.GameStart)
        {
            StartTime -= Time.deltaTime;
        }
        
        _timerText.text = "Time Left :"+StartTime.ToString("0");

        if (StartTime <= 0&&!_gameManage.GameFinish)
        {
            _gameManage.GameFinish = true;
        }
	}
}
