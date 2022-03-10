using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using System.Text;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public PhotonView view;
    public Rigidbody rb;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 180f;
    public string str;
    public Color color;
    public Text nameText;
    public float test;
    public bool yes = false;
    public byte[] arr = { 0, 0, 0 };
    public GameObject menupanel;
    public GameObject player;
    public GameObject playerCrouch;
    public GameObject playerCrouch2;
    public KeyCode forward = KeyCode.W;
    public KeyCode back = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode jump = KeyCode.Space;
    public KeyCode crouch = KeyCode.LeftControl;
    public KeyCode sprint = KeyCode.LeftShift;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        view = GetComponent<PhotonView>();
        menupanel = GameObject.Find("MenuPanel");
        //color = new Color(arr[0] * 0.01f, arr[0] * 0.01f, arr[0], 1);
        //hex += (e - 96).ToString();
    }

    void Update()
    {
        if (menupanel.transform.localScale == new Vector3(1.03f, 1.03f, 1)) canMove = false;
        if (menupanel.transform.localScale == new Vector3(0, 0, 0)) canMove = true;

        str = nameText.text;
        arr = Encoding.ASCII.GetBytes(str);
        foreach (int element in arr) { 
            if(yes == false) test += element;
        }
        if(arr != null)
        {
            yes = true;
        }
        if(test >= 700)color = new Color(((test - 34) * 0.03f) * 0.1f, ((test - 34) * 0.03f) * 0.1f, ((test - 34) * 0.01f) * 0.1f, 1);
        if(test >= 400 && test <= 500) color = new Color(((test - 34) * 0.01f) * 0.1f, ((test - 34) * 0.03f) * 0.1f, ((test - 34) * 0.03f) * 0.1f, 1);
        if(test <= 400) color = new Color(((test - 34) * 0.03f) * 0.1f, ((test - 34) * 0.01f) * 0.1f, ((test - 34) * 0.03f) * 0.1f, 1);
        this.gameObject.transform.GetChild(1).transform.GetComponent<MeshRenderer>().material.color = color;
        this.gameObject.transform.GetChild(2).transform.GetComponent<MeshRenderer>().material.color = color;
        this.gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<MeshRenderer>().material.color = color;
        this.gameObject.transform.GetChild(0).transform.GetChild(1).transform.GetComponent<MeshRenderer>().material.color = color;
        if (view.IsMine)
        { 
            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }
            if (Input.GetKey(forward) && canMove && Input.GetKey(sprint))
            {
                rb.velocity = new Vector3(transform.forward.x * 9.5f, rb.velocity.y, transform.forward.z * 9.5f);//new Vector3(rb.velocity.x, rb.velocity.y, );
            }
            else if (Input.GetKey(forward) && canMove)
            {
                rb.velocity = new Vector3(transform.forward.x * 7, rb.velocity.y, transform.forward.z * 7);//new Vector3(rb.velocity.x, rb.velocity.y, );
            }

            if (Input.GetKey(back) && canMove)
            {
                rb.velocity = new Vector3(transform.forward.x * -6, rb.velocity.y, transform.forward.z * -6);//new Vector3(rb.velocity.x, rb.velocity.y, );
            }
            if (Input.GetKey(right) && canMove) {
                rb.velocity = new Vector3(transform.right.x * 6, rb.velocity.y, transform.right.z * 6);
            }
            if (Input.GetKey(left) && canMove) {
                rb.velocity = new Vector3(transform.right.x * -6, rb.velocity.y, transform.right.z * -6);
            }
            if (Input.GetKey(crouch) && canMove)
            {
                player.transform.localScale = new Vector3(0,0,0);
                playerCrouch.transform.localPosition = new Vector3(0,0,0);
                playerCrouch2.transform.localPosition = new Vector3(0, -0.5f, 0);
            }
            else
            {
                player.transform.localScale = new Vector3(1, 1, 1);
                playerCrouch.transform.localPosition = new Vector3(0, 0.5f, 0);
                playerCrouch2.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
        else
        {
            this.gameObject.transform.GetChild(0).transform.GetComponent<Camera>().enabled = false;
        }
    }

    void OnTriggerStay(Collider x)
    {
        if (Input.GetKey(jump) && canMove)
        {
            rb.velocity = new Vector3(rb.velocity.x, 5, rb.velocity.z);
        }
    }
}
