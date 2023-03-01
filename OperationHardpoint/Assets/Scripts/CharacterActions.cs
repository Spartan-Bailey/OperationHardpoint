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

    [SerializeField] float dist = 7f;

    [SerializeField] private LayerMask Ground;

    [SerializeField] private PhysicsMaterial2D MaxFriction;
    [SerializeField] private PhysicsMaterial2D NoFriction;
    void Start()
    {
        Rigidbody = transform.GetComponent<Rigidbody2D>();
        Collider = transform.GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        SlopeCheck();
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
    public void Jump() // call for the player to attempt to jump
    {
        if (IsGrounded())
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, jumpVelocity);
        }
    }
    public void Walk() // call for the player to walk
    {
        if (IsGrounded() && IsOnSlope())
        {
            Rigidbody.velocity = new Vector2(-drX * Perpendicular.x * movementSpeed, Perpendicular.y * -drX * movementSpeed);
        }
        else
        {
            Rigidbody.velocity = new Vector2(drX * movementSpeed, Rigidbody.velocity.y);
        }
    }

    public bool IsGrounded()
    {
        return (Physics2D.BoxCast(Collider.bounds.center, Collider.bounds.size, 0f, Vector2.down, .1f, Ground));
    }

    private bool IsOnSlope()
    {
        return isOnSlope;
    }


    Vector2 Perpendicular;
    float slopeAngle;
    float oldAngle;
    bool isOnSlope;
    private void SlopeCheck()
    {
        Vector2 checkpos = transform.position - new Vector3(0f, Collider.bounds.size.y / 2f);
        RaycastHit2D hit = Physics2D.Raycast(checkpos, Vector2.down, dist, Ground);
        if (hit)
        {
            Debug.DrawRay(hit.point, hit.normal, Color.blue);
            Perpendicular = Vector2.Perpendicular(hit.normal).normalized;
            slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
            Debug.DrawRay(hit.point, Perpendicular, Color.red);
        }
        if(slopeAngle != oldAngle)
        {
            isOnSlope = true;
            if(drX == 0f){
                Rigidbody.sharedMaterial = MaxFriction;
            }
            else
            {
                Rigidbody.sharedMaterial = NoFriction;
            }
        }
        else
        {
            isOnSlope = false;
        }
        

    }

}
