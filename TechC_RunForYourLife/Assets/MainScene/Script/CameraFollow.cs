using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject Player;
    public float FollowSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float DelayTime = FollowSpeed * Time.deltaTime;
        Vector3 Position = this.transform.position;
        Position.x = Mathf.Lerp(this.transform.position.x, Player.transform.position.x, DelayTime);
        Position.z = Mathf.Lerp(this.transform.position.z, Player.transform.position.z-2.5f, DelayTime);

        transform.position = Position;		
	}
}
