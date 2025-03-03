using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidBody;
    [SerializeField] float playerSpeed = 2000;
    [SerializeField] float jumpHeight = 10;
    [SerializeField] bool onGround = true;
    [SerializeField] bool canJump = true;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MovePlayer(Vector3 input)
    {
        Vector3 inputXZPlane = new Vector3(input.x, 0, input.z).normalized;
        if (onGround)
        {
            canJump = true;
            inputXZPlane.y = input.y * jumpHeight;
        } else if (input.y > 0)
        {
            if (canJump)
            {
                inputXZPlane.y = input.y * jumpHeight;
                canJump = false;
            }
        }
        playerRigidBody.AddForce(transform.forward * inputXZPlane.z * playerSpeed * Time.deltaTime);
        playerRigidBody.AddForce(transform.right * inputXZPlane.x * playerSpeed * Time.deltaTime);
        playerRigidBody.AddForce(transform.up * inputXZPlane.y * playerSpeed * Time.deltaTime, ForceMode.Impulse);
    }

    public void RotatePlayer(float input)
    {
        transform.Rotate(Vector3.up * input);
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
