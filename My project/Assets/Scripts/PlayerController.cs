using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidBody;
    [SerializeField] float playerSpeed = 50;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] float jumpHeight = 20;
    [SerializeField] float dashForce = 500;
    [SerializeField] bool onGround = true;
    [SerializeField] bool canJump = true;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MovePlayer(Vector3 input)
    {
        Vector3 inputXZPlane = new Vector3(input.x, 0, input.z).normalized;
        playerRigidBody.AddForce(transform.forward * inputXZPlane.z * playerSpeed);
        playerRigidBody.AddForce(transform.right * inputXZPlane.x * playerSpeed);

        if (input.magnitude < 0.01f)
        {
            // I did this instead of the physics so it would decelerate correctly in the air. I was getting funky results where the player would go super speed when moving in the air.
            // I guess in hindsight I could've made no inputs work in the air and made it so the player was stuck jumping in one direction, but I did not do that.
            playerRigidBody.AddForce(new Vector3(-playerRigidBody.linearVelocity.x, 0, -playerRigidBody.linearVelocity.z) * 5, ForceMode.Acceleration);
        }

        if (playerRigidBody.linearVelocity.magnitude > maxSpeed)
        {
            playerRigidBody.linearVelocity = playerRigidBody.linearVelocity.normalized * maxSpeed;
        }
    }

    public void RotatePlayer(float input)
    {
        transform.Rotate(Vector3.up * input);
    }

    public void Jump()
    {
        if (onGround)
        {
            playerRigidBody.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            canJump = true;
        }
        else if (canJump)
        {
            playerRigidBody.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            canJump = false;
        }
    }

    public void Dash()
    {
        playerRigidBody.AddForce(transform.forward * dashForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("Ground")) onGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("Ground")) onGround = false;
    }
}
