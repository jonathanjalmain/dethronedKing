using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private Vector2 moveInput;
    [SerializeField] private bool _isMoving = false;
    [SerializeField] private bool _isFightZone = false;

    public bool isFightZone { get {
        return _isFightZone;
    }
        set {
            _isFightZone = value;
            animator.SetBool("isFightZone", value);
        }
    }
    public bool isMoving { get {
        return _isMoving;
    }
        private set {
            _isMoving = value;
            animator.SetBool("isMoving", value);
        }
    }
    Rigidbody2D rb;
    Animator animator;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        isMoving = moveInput != Vector2.zero;
        setFacingDirection(moveInput);
    }

    private void setFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        } else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void OnFight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isFightZone = true;
        } else if (context.canceled)
        {
            isFightZone = false;
        }
    }
}
