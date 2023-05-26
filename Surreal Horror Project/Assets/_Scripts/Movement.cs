using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public LayerMask ground;
    public LayerMask stairs;

    [SerializeField] float force = 5f;
    [SerializeField] float drag = 3f;

    [SerializeField] float jumpVelocity = 5;
    [SerializeField] float speed = 5;
    [SerializeField] float runSpeed = 10;
    [SerializeField] float crouchWalkSpeed = 2.5f;

    [SerializeField] float crouchingSpeed = 3f;
    [SerializeField] float crouchHeight = 1f;

    [SerializeField] float groundCheckRadius = .2f;

    [SerializeField] Transform reach;
    [SerializeField] Transform body;
    [SerializeField] Transform knee;
    [SerializeField] Transform feet;

    [SerializeField, Range(0, 360)] float _angle = 45f;
    [SerializeField] int count = 5;
    [SerializeField] float stepRate = 17.5f;

    Rigidbody rb;
    CapsuleCollider collider;
    
    //[SerializeField,Range(0,1)]
    //float stamina;

    float defaultHeight;
    float targetHeight;
    float currentSpeed;
    float currentDrag;
  
    bool jump;
    bool holdCrouch;
    bool toggleCrouch = false;

    public float velocityMag { get; private set; }
    public bool crouched { get; private set; }
    public bool grounded { get; private set; }
    public Vector3 movementVector { get; private set; }
    public Vector3 inputVector { get; private set; }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        defaultHeight = 1.7f;
        targetHeight = defaultHeight;
    }
   
    void Update()
    {
        velocityMag = rb.velocity.magnitude;

        HandleInput();

        HandleSpeed();

        HandleJump();

        HandleCrouch();

        handleStairs();

        //HandleLedge();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    #region

    void HandleInput()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movementVector = transform.TransformDirection(inputVector);
        jump = Input.GetButtonDown("Jump");
    }

    void HandleSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }
        else if (crouched)
        {
            currentSpeed = crouchWalkSpeed;
        }
        else
        {
            currentSpeed = speed;
        }
    }

    void HandleMovement()
    {
        if (grounded)
        {
            rb.AddForce(movementVector * currentSpeed , ForceMode.Force);
        }
        else
        {

        }
        currentDrag = grounded ? drag : 0;

        rb.drag = currentDrag;

    }

    void HandleJump()
    {
        grounded = Physics.CheckSphere(feet.position, groundCheckRadius, ground);
        if (jump && grounded)
        {
            Jump();
        }
    }

    //tofix
    void HandleCrouch()
    {
        holdCrouch = Input.GetKey(KeyCode.LeftControl);
        if (Input.GetKeyDown(KeyCode.C))
        {
            toggleCrouch = !toggleCrouch;
        }
        if (toggleCrouch)
        {
            crouched = toggleCrouch;
        }
        else
        {
            crouched = holdCrouch;
        }

        targetHeight = crouched ? crouchHeight : defaultHeight;
        if (collider.height != targetHeight)
        {
            collider.height = Mathf.Lerp(collider.height, targetHeight, (crouchingSpeed * Time.deltaTime) * (crouchingSpeed * Time.deltaTime));
        }
    }

    void HandleLedge()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(body.position, transform.forward, .5f))
            {
                if (!Physics.Raycast(reach.position, transform.forward, .5f))
                {
                    StartCoroutine(climb());
                }
            }
        }
    }

    public float climbSpeed;

    IEnumerator climb()
    {
        Vector3 targetPosition = rb.position + new Vector3(0, 3, 0);
        while ( .5f < Vector3.Distance(rb.position,targetPosition)&&Input.GetKey(KeyCode.Space))
        {
            //curve

            rb.position = new Vector3(rb.position.x, Mathf.Lerp(rb.position.y, targetPosition.y,Mathf.Clamp01(1 - (1 - climbSpeed) * (1 - climbSpeed))), rb.position.z);
            yield return new WaitForFixedUpdate();
        }
    }

    void Jump()
    {
        rb.velocity += Vector3.up * jumpVelocity;
    }

    void handleStairs()
    {
        bool tooHigh = false;

        float angle = _angle;
        float angleIncrease = angle / count;

        for (int i = 0; i < count; i++)
        {
            float rad = angle * (Mathf.PI / 180);
            Vector3 direction = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad));
            Ray ray = new Ray(knee.position, transform.TransformDirection(direction));
            tooHigh = Physics.Raycast(ray, out RaycastHit hit, .5f, stairs);
            if (tooHigh)
            {
                //Debug.DrawLine(knee.position, hit.point);
                i = count;
            }
            else
            {
                //Debug.DrawRay(knee.position, ray.direction * .5f);
            }
            angle -= angleIncrease;
        }

        if (tooHigh)
        {
            return;
        }

        bool checkStairs = false;

        angle = _angle;

        for (int i = 0; i < count; i++)
        {
            float rad = angle * (Mathf.PI / 180);
            Vector3 direction = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad));
            Ray ray = new Ray(feet.position, transform.TransformDirection(direction));
            checkStairs = Physics.Raycast(ray, out RaycastHit hit, .6f, stairs);
            if (checkStairs)
            {
                Debug.DrawLine(feet.position, hit.point);
                i = count;
            }
            else
            {
                Debug.DrawRay(feet.position, ray.direction * .6f);
            }
            angle -= angleIncrease;
        }

        if (checkStairs && movementVector.magnitude >= 0.1f)
        {
            rb.velocity += Vector3.up * stepRate * Time.deltaTime;
            Debug.Log("stairs");
        }
    }

    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(feet.position, groundCheckRadius);
    }
}
