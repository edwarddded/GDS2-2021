using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    public Rigidbody rb;
    
    //Restricts inventory / building UI when player is trying to place a tower
    //This boolean can also be used to restrict other player functions later
    public bool isBuilding;
    //*****
    private Vector3 movedirection;
    public CharacterController controller;

    public float trunSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;

    //*****
    private Vector3 velocity;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;
    //*****
    public GameObject map;

    //Player animation
    private Animator PlayerAnimator;
    private void Start()
    {
        isBuilding = false;
        //col = GetComponent<CapsuleCollider>();
        PlayerAnimator = GetComponentInChildren<Animator>();
        //*****
        controller = GetComponent<CharacterController>();
        //*****
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (map != null)
            {
                bool isActive = map.activeSelf;
                map.SetActive(!isActive);
            }
        }
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y< 0)
        {
            velocity.y = -2f;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction != Vector3.zero)
        {
            PlayerAnimator.SetBool("Run", true);
            Debug.Log("Move");
        }
        else if (direction == Vector3.zero)
        {
            PlayerAnimator.SetBool("Run", false);
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, trunSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * movementSpeed * Time.deltaTime);
        }

        if (isGrounded)
        {
            PlayerAnimator.SetBool("isGround", true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
                PlayerAnimator.SetTrigger("Jump");
            }
        }
        else if (!isGrounded)
        {
            PlayerAnimator.SetBool("isGround", false);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy2")
        {
            StartCoroutine(PlayerFreeze());
        }
    }
    IEnumerator PlayerFreeze()
    {
        movementSpeed = 0;
        yield return new WaitForSeconds(0.75f);
        movementSpeed = 10;
    }

    private void FixedUpdate()
    {
  
    }
}
