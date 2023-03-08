using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Camera")]
    [SerializeField] private Camera playerCam;

    [Header("Player Stats")]
    [SerializeField] private float moveSpeed = 1.5f;
    [SerializeField] private float maxSpeedWhileWalking;
    //[SerializeField] private float maxSpeedWhileRunning = 10f;
    [SerializeField] private float gravity = 50f;

    private float maxSpeed;
    private PlayerInputBinds playerInputBinds;
    private InputAction move;
    private Rigidbody rb;
    private Vector3 forceDirection = Vector3.zero;
    private bool canMove = true;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        playerInputBinds = new PlayerInputBinds();
    }

    private void OnEnable()
    {
        move = playerInputBinds.Player.Walk;
        playerInputBinds.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputBinds.Player.Disable();
    }
    private void Start()
    {
        playerCam = Camera.main;
        maxSpeed = maxSpeedWhileWalking;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Speedcontrol();
            Move();
            Run();
        }
            Vector2 _direction = new Vector2(rb.velocity.x, rb.velocity.z);
            FindObjectOfType<PlayerAnimator>().SetDirection(_direction);

    }
    private void Speedcontrol()
    {

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

    }
    private void Move()
    {
        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCam) * moveSpeed;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCam) * moveSpeed;
        rb.AddForce(forceDirection, ForceMode.Impulse);

        if (rb.velocity.y < 0f)
        {
            rb.velocity += Vector3.down * gravity * Time.fixedDeltaTime;
        }

        forceDirection = Vector3.zero;

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;
        }
    }
    private void Run()
    {
        {
            maxSpeed = maxSpeedWhileWalking;
        }
    }

    private Vector3 GetCameraForward(Camera playerCam)
    {
        Vector3 forward = playerCam.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCam)
    {
        Vector3 right = playerCam.transform.right;
        right.y = 0;
        return right.normalized;
    }

    public void DisableMovement()
    {
        canMove = false;
        maxSpeed = 0f;
    }

    public void EnableMovement()
    {
        canMove = true;
    }
}
