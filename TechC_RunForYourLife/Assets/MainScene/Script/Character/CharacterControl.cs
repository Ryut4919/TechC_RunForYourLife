using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour {
    public float MoveSpeed;
    private Vector3 Direction;
    private Animator _animator;
    private CharacterController _charController;
    
    [SerializeField]
    private Manager _manager;
    [SerializeField]
    private GameObject _Redfade;

    public bool FpsMode;
    public bool TpsMode;
    
    Vector3 Dir;


    public bool Deteched;

    // Use this for initialization
    void Start () {
        _animator = this.GetComponent <Animator>();
        _charController = GetComponent<CharacterController>();
        FpsMode = true;
        TpsMode = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //  Playermove();
        if (FpsMode)
        {
            FpsPlayermove();
        }

        if (TpsMode)
        {
            TpsPlayerMove();
        }

        if (Deteched)
        {
            StartCoroutine("WowStart");
        }
        else
        {
            _Redfade.SetActive(false);
        }

    }

    public void FpsOn()
    {
        FpsMode = true;
        TpsMode = false;
    }

    public void TpsOn()
    {
        FpsMode = false;
        TpsMode = true;
    }

   private void FpsPlayermove()
    {
        if (_manager.GameStart)
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
        
    }

    private void TpsPlayerMove()
    {
        Debug.Log("Tps");
       

        #region 操作
        
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 0.5f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 0.5f;

            Dir = new Vector3(x, 0, z);

            if (Dir.sqrMagnitude > 0f)
            {
                this.GetComponent<Animator>().SetBool("Run", true);
                Vector3 destination = transform.position + Dir.normalized * 0.1f;
                Quaternion seq = Quaternion.LookRotation(destination - transform.position, Vector3.up);

                transform.position = destination;
                transform.rotation = seq;
            }
            else
            {
                this.GetComponent<Animator>().SetBool("Run", false);
            }
        

        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ClearZone")
        {
            _manager.GameClear = true;
        }
    }

    IEnumerator WowStart()
    {
        _Redfade.SetActive(true);
        yield return new WaitForSeconds(1f);
       
        Deteched = false;
    }

    void OnCallChangeFace()
    {

    }
}
