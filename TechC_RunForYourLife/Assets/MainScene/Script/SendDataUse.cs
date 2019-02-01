using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendDataUse : MonoBehaviour {
    [SerializeField]
    SSDataControl _ssData;

    private bool Sended = false;
    private int gameMode;
    private int MaxMode;
    public int Score;
    private int MaxScore;
    // Use this for initialization
	void Start ()
    {
        Sended = true;
        gameMode =0;
        MaxMode = 1;
        MaxScore = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Sended)
        {
            _ssData.SaveData(gameMode, MaxMode, Score, MaxScore);
            Sended = false;

            StartCoroutine("CloseWindow");
        }	
	}

    IEnumerator CloseWindow()
    {
        yield return new WaitForSeconds(4.0f);
        Application.Quit();
    }
}
