using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Xml;
using TreeEditor;
using UnityEngine;

public class playerControllerRB : MonoBehaviour
{
    #region Settings
    public float walkSpeed = 0f;
    public float sprintSpeed = 0f;
    public float jumpHeight = 0f;
    #endregion

    #region tools
    public Rigidbody rb;
    private float speed;
    #endregion

    #region Keys
    public KeyCode forward = KeyCode.W;
    public KeyCode left = KeyCode.A;
    public KeyCode back = KeyCode.S;
    public KeyCode right = KeyCode.D;
    public KeyCode jump = KeyCode.Space;
    public KeyCode crouch = KeyCode.LeftControl;
    public KeyCode sprint = KeyCode.LeftShift;
    #endregion

    #region statCheck
    private bool bForward;
    private bool bLeft;
    private bool bBack;
    private bool bRight;
    private bool bJump;
    private bool bCrouch;
    private bool bSprint;
    #endregion


    void Start()
    {

        rb = GetComponent<Rigidbody>();
        speed = walkSpeed;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {

        #region grounded
        bool grounded = Physics.Raycast(transform.position, Vector3.down, 1.5f);
        #endregion

        #region Controlls
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        #endregion

        #region Movement
        float translation = v * speed * Time.deltaTime;
        float straffe = h * speed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);


        #region jump
        if (Input.GetKeyDown(jump) & grounded == true)
        {
            rb.AddForce(Vector3.up * jumpHeight);
        }
        #endregion

        #region sprint
        if (Input.GetKey(sprint))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
        #endregion
        #endregion

    }
}
