using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private float MoveSpeed = 5f;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * MoveSpeed * Time.deltaTime;

        Vector3 newPosition = rb.position + movement;

        rb.MovePosition(newPosition);
    }
}
