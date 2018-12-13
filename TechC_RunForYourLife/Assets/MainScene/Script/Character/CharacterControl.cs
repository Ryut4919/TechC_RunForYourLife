using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {
    public float MoveSpeed;
    private Vector3 Direction;
    private Animator _animator;

	// Use this for initialization
	void Start () {
        _animator = this.GetComponent <Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        var xDir = Input.GetAxis("Horizontal") * Time.deltaTime;
        var zDir = Input.GetAxis("Vertical") * Time.deltaTime;

        Direction = new Vector3(xDir, 0, zDir);

        if (Direction.sqrMagnitude > 0f)
        {
            Vector3 des = transform.position + Direction.normalized * MoveSpeed;
            //Quaternion Roll = Quaternion.LookRotation(des - transform.position, Vector3.up);

            transform.position = des;
            //transform.rotation = Roll;


            _animator.SetBool("Run", true);
        }
        else
        {
            _animator.SetBool("Run", false);
        }
        	
	}
    void OnCallChangeFace()
    {

    }
}
