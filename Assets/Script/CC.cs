using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC : MonoBehaviour
{
    public float jumpStrength, speed;
    float dirHorizontal, dirVertical;  

    public bool isJumping, isRunning, isCrouching;

    Vector3 standTrans, standSize, standCenter, crouchTrans, crouchSize, crouchCenter;

    Rigidbody _rb;
    BoxCollider _bc;
    Camera _c;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _bc = GetComponent<BoxCollider>();
        _c = GetComponentInChildren<Camera>();        

        standTrans = _c.transform.position;
        standSize = _bc.size;
        standCenter = _bc.center;
        
        crouchSize = new Vector3(1, 0.8f, 1);
        crouchCenter = new Vector3(0, -0.6f, 0); ;

        jumpStrength = 5f;
        speed = 0.1f;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        dirHorizontal = Input.GetAxis("Horizontal");
        dirVertical = Input.GetAxis("Vertical");

        crouchTrans = new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z);
        standTrans = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {           
            Vector3 move = new Vector3(dirHorizontal, 0, dirVertical) * speed;
            Vector3 newPosition = _rb.transform.position + _rb.transform.TransformDirection(move);
            _rb.MovePosition(newPosition);    
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;           
        }      

        if (isRunning)
        {
            speed = 0.25f;
            StartCoroutine(StopRunning());
        }
        else
        {
            speed = 0.1f;
        }

        if(Input.GetKey(KeyCode.LeftControl) && !isCrouching)
        {
            Crouch();
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Stand();
        }
    }

    #region MovementVoids
    private void Crouch()
    {
        _c.transform.position = crouchTrans;
        _bc.size = crouchSize;
        _bc.center = crouchCenter;
        isCrouching = true;
    }

    private void Stand()
    {
        _c.transform.position = standTrans;
        _bc.size = standSize;
        _bc.center = standCenter;
        isCrouching = false;
    }

    void Jump()
    {
        _rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        isJumping = true;
    }

    IEnumerator StopRunning()
    {
        yield return new WaitForSeconds(1.2f);
        isRunning = false;
        StopCoroutine(StopRunning());
    }
    
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 13)
        {
            isJumping = false;            
        }
    }   
}
