using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{

   
    public static Controller controller;

    //player movement
    public PlayerControls inputAction;
    Vector2 move;
    Vector2 look;
    [SerializeField]
    private float walkSpeed= 3f;
    [SerializeField]
    private float runSpeed =5f;
    public Camera playerCam;
    Vector3 cameraRotation;



    //player jump
    Rigidbody body;
    private float distanceToGround;
    private bool isGrounded = true;
    [SerializeField]
    private float jumpPower = 5.0f;

    //Player animation
    Animator playerAnimator;
    private bool isWalking = false;
    
    //player bullets
    public GameObject bullet;
    public Transform bulletSpawn; 


    

    private void OnEnable() {
        inputAction.Enable();
    }

    private void OnDisable() {
        inputAction.Disable();
    }


    // Start is called before the first frame update
    void Awake()
    {

        inputAction = new PlayerControls();

        inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.Jump.canceled += cntxt => Jump();
        inputAction.Player.Shoot.performed += cntxt => Shoot();

        body = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>(); 

        distanceToGround = GetComponent<Collider>().bounds.extents.y;
    }
    
    private void Shoot()
    {

        Rigidbody bulletRb = Instantiate(bullet, bulletSpawn.position , Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * 1.6f, ForceMode.Impulse);
        bulletRb.AddForce(transform.up * 0.4f, ForceMode.Impulse);
    }   

    private void Jump()
    {
        if(isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * move.y * Time.deltaTime * walkSpeed, Space.Self);
        transform.Translate(Vector3.right * move.x * Time.deltaTime * walkSpeed, Space.Self);

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distanceToGround);

    }
}
