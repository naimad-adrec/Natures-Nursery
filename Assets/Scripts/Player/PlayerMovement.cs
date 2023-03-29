using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    // Game Components
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    // Movement Variables
    [SerializeField] private float moveSpeed = 5f;
    private Vector3 moveDir;
    private Vector2 playerInput;
    private float dirX;
    private float dirY;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // Recieve Player Input
        dirY = Input.GetAxisRaw("Vertical");
        dirX = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        // Apply Player Movement
        playerInput = new Vector2(dirX, dirY).normalized;
        moveDir = new Vector3(playerInput.x * moveSpeed * Time.fixedDeltaTime, playerInput.y * moveSpeed * Time.fixedDeltaTime, transform.position.z);
        rb.velocity = moveDir;
    }
}