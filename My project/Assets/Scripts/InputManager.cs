using System;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();
    public UnityEvent<float> OnDrag = new UnityEvent<float>();
    public float horizontal;


    void Update()
    {
        Vector3 inputVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) inputVector += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) inputVector += Vector3.back;
        if (Input.GetKey(KeyCode.D)) inputVector += Vector3.right;
        if (Input.GetKey(KeyCode.A)) inputVector += Vector3.left;
        if (Input.GetKeyDown(KeyCode.Space)) inputVector += Vector3.up;
        if (Input.GetKeyDown(KeyCode.LeftShift)) inputVector += Vector3.forward;


        horizontal = Input.GetAxis("Mouse X");

        OnMove?.Invoke(inputVector);
        OnDrag?.Invoke(horizontal);
    }
}
