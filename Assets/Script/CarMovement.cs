using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] public float steerSpeed = 1f;
    [SerializeField] public float runSpeed = 1f;

    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = new Vector2(0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal")*Time.deltaTime;
        float verticalInput = Input.GetAxis("Vertical")*Time.deltaTime;

        float steerMove = horizontalInput * steerSpeed;
        float runMove = verticalInput * runSpeed;

        transform.Rotate(0, 0, -steerMove);
        transform.Translate(0, runMove, 0);
    }
}
