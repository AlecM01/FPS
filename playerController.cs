using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using UnityEngine;


public class playerController : MonoBehaviour
{

    public CharacterController cc;
    private Vector3 playerVelocity;

    #region controlls
    public KeyCode forward = KeyCode.W;
    public KeyCode left = KeyCode.A;
    public KeyCode back = KeyCode.S;
    public KeyCode right = KeyCode.D;
    public KeyCode jump = KeyCode.Space;
    public KeyCode crouch = KeyCode.LeftControl;
    #endregion

    #region bool
    private bool bForward;
    private bool bLeft;
    private bool bBack;
    private bool bRight;
    private bool bCrouch;
    #endregion

    #region settings
    public float playerSpeed = 6;
    public float jumpHeight = 2f;
    public float gravityValue = 9.81f;
    private float verticalSpeed = 0;
    public float sensitivityX = 4f;
    public float sensitivityY = 4f;
    #endregion


    // Start is called before the first frame update
    void Start()
    {

        cc = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        Move();
        cam();
        Gravity();

    }

    private void Move()
    {

        bool grounded = Physics.Raycast(transform.position, Vector3.down, 0.5f);

        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(playerSpeed * Time.deltaTime * move);

        float jumpMove = Input.GetAxis("Jump");
        Vector3 jumpS = transform.up * jumpMove;

        if (Input.GetKeyDown(jump) & grounded == true)
        {
            cc.Move(transform.up * jumpHeight);
            print("true");
        }

    }

    private void cam()
    {
        float h = sensitivityX * Input.GetAxisRaw("Mouse X");
        float v = sensitivityY * Input.GetAxisRaw("Mouse Y");
        transform.Rotate(0, h, 0);

        
    }

    private void Gravity()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        if (cc.isGrounded) verticalSpeed = 0;
        else verticalSpeed -= gravityValue * Time.deltaTime;

        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);
        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(playerSpeed * Time.deltaTime * move + gravityMove * Time.deltaTime);

        

    }
}
