using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {
    public float MoveSpeed;
    private Vector3 Direction;
    private Animator _animator;
    private CharacterController _charController;

   

	// Use this for initialization
	void Start () {
        _animator = this.GetComponent <Animator>();
        _charController = GetComponent<CharacterController>();
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        Playermove();
    }



    void Playermove()
    {
        float xDir = Input.GetAxis("Horizontal") * MoveSpeed;
        float zDir = Input.GetAxis("Vertical") * MoveSpeed;

        Vector3 ForwardMove = transform.forward * zDir;
        Vector3 RightMove = transform.right * xDir;

        _charController.SimpleMove(ForwardMove + RightMove);

        Direction = new Vector3(xDir, 0, zDir);

        if (Direction.sqrMagnitude > 0)
        {
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
