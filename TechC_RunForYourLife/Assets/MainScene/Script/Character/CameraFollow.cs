using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public int x, y, z;
    public GameObject player;
    public float followSpd;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float interpolation = followSpd * Time.deltaTime;

        Vector3 position = this.transform.position;
        position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x - x, interpolation);
        position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y + y, interpolation);
        position.z = Mathf.Lerp(this.transform.position.z, player.transform.position.z - z, interpolation);
        this.transform.position = position;
    }
}
