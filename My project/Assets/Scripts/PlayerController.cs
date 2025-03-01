using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidBody;
    [SerializeField] float playerSpeed = 2000;
    [SerializeField] float jumpHeight = 100;
    [SerializeField] bool onGround = true;
    [SerializeField] bool canJump = true;

    public void movePlayer(Vector3 input)
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
        playerRigidBody.AddForce(inputXZPlane * playerSpeed * Time.deltaTime);
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
