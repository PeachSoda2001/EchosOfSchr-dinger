using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance;
    CharacterController playerController;

    public float speed = 1;
    public float jumpPower = 5;
    public float gravity = 7f;

    public float mousespeed = 5f;

    public float minmouseY = -45f;
    public float maxmouseY = 45f;

    float RotationY = 0f;
    float RotationX = 0f;
    Vector3 direction;

    public Transform agretctCamera;
    public Vector3 velocityY;
    public bool IsFlying;
    private bool startFlying;
    private float originGravity;
    // Start is called before the first frame update
    void Start()
    {
        playerController = this.GetComponent<CharacterController>();
        velocityY = Vector3.zero;
        IsFlying = false;
        startFlying = false;
        originGravity = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        bool isGround = playerController.isGrounded;
        //print(isGround);
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");
        
        direction = new Vector3(_horizontal * speed, 0, _vertical * speed);
        if(!isGround)
        {
            velocityY.y -= gravity * Time.deltaTime;
        }
        else
        {
            velocityY.y -= gravity * Time.deltaTime *0.1f;
        }

        if ((Input.GetKeyDown(KeyCode.Space) && isGround && !IsFlying)
            || startFlying)
        {
            if (velocityY.y < 0)
            {
                velocityY.y = 0;
            }
            velocityY.y += Mathf.Sqrt(jumpPower * 2 * gravity);
            if(startFlying)
            {
                IsFlying = true;
                startFlying = false;
            }
        }

        if(IsFlying && velocityY.y<0)
        {
            velocityY.y = 0;
            gravity = 0;
        }

        playerController.Move(playerController.transform.TransformDirection(direction * Time.deltaTime));
        playerController.Move(velocityY * Time.deltaTime);

        RotationX += agretctCamera.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mousespeed;

        RotationY -= Input.GetAxis("Mouse Y") * mousespeed;
        RotationY = Mathf.Clamp(RotationY, minmouseY, maxmouseY);

        this.transform.eulerAngles = new Vector3(0, RotationX, 0);

        agretctCamera.transform.eulerAngles = new Vector3(RotationY, RotationX, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LEVEL_LOADER")
        {
            GameManager.Instance.HandleLoadLevel();
        }
        else if(other.tag == "DEATH")
        {
            GameManager.Instance.HandleLoadLevel(true);
        }
        else if(other.tag == "FLY")
        {
            startFlying = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "FLY")
        {
            IsFlying = false;
            gravity = originGravity;
        }
    }



}
