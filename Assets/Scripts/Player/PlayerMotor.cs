using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera playerCamera;

    private Vector3 velocity = Vector3.zero;
    private Vector3 velocityOnJumping = Vector3.zero;
    private Vector3 horizontalRotation = Vector3.zero;
    private Vector3 verticalRotation = Vector3.zero;

    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    private bool furtiveMode = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void FixedUpdate()
    {
        PerformMovementOfPlayer();
        PerformRotationOfPlayer();
        PerformRotationOfCamera();
    }

    private void PerformMovementOfPlayer()
    {
        if (velocity != Vector3.zero) {
            //if (isGrounded())
            if(furtiveMode)
                rb.MovePosition(rb.position + (velocity/2.0f) * Time.fixedDeltaTime);
            else
                rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
                
    }

    private void PerformRotationOfPlayer()
    {
        rb.transform.rotation = Quaternion.Euler(horizontalRotation);
    }

    private void PerformRotationOfCamera()
    {
        verticalRotation.x = Mathf.Clamp(verticalRotation.x, -90, 90);
        if (playerCamera != null)
            playerCamera.transform.rotation = Quaternion.Euler(verticalRotation.x, horizontalRotation.y, 0);
    }

    public void MovePlayer(Vector3 velocity)
    {
        this.velocity = velocity;
    }

    public void RotatePlayer(Vector3 horizontalRotation)
    {
        this.horizontalRotation += horizontalRotation;
    }

    public void RotateCamera(Vector3 verticalRotation)
    {
        this.verticalRotation += verticalRotation;
    }

    public void Jump(float jumpForce)
    {
        /*
        if (isGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            velocityOnJumping = velocity;
        }*/
    }

    public void ToggleFurtiveMode()
    {
        furtiveMode = !furtiveMode;
    }

    public bool isFurtive()
    {
        return furtiveMode;
    }

    private bool isGrounded()
    {
        RaycastHit hitInfo;
        return (Physics.SphereCast(transform.position, capsuleCollider.radius, Vector3.down, out hitInfo,
             0.5f, Physics.AllLayers, QueryTriggerInteraction.Ignore));
    }
}
