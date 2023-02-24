using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
    float drX;
    float drY;

    private Rigidbody2D Rigidbody;
    private Collider2D Collider;
    // Character Traits
    [SerializeField] float movementSpeed = 7f;
    [SerializeField] float jumpVelocity = 7f;

    [SerializeField] private LayerMask jumpableGround;
    void Start()
    {
        Rigidbody = transform.GetComponent<Rigidbody2D>();
        Collider = transform.GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDrX(float x)
    {
        drX = x;
    }
    public void SetDrY(float y)
    {
        drY = y;
    }
    public float GetMovementSpeed()
    {
        return movementSpeed;
    }
    public void ToggleCrouch()
    {

    }
    public void Jump()
    {
        if (IsGrounded())
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, jumpVelocity);
        }
    }
    public void Walk()
    {
        Rigidbody.velocity = new Vector2(drX * movementSpeed, Rigidbody.velocity.y);
    }

    private bool IsGrounded()
    {
        return (Physics2D.BoxCast(Collider.bounds.center, Collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround));
    }
}
