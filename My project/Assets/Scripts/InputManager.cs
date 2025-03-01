using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();
    void Update()
    {
        Vector3 inputVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) inputVector += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) inputVector += Vector3.back;
        if (Input.GetKey(KeyCode.D)) inputVector += Vector3.right;
        if (Input.GetKey(KeyCode.A)) inputVector += Vector3.left;
        if (Input.GetKeyDown(KeyCode.Space)) inputVector += Vector3.up;
        if (Input.GetKeyDown(KeyCode.LeftShift)) inputVector += Vector3.forward * 1000;

        OnMove?.Invoke(inputVector);
    }
}
