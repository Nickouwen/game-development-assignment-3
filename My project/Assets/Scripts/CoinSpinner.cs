using UnityEngine;

public class CoinSpinner : MonoBehaviour
{
    [SerializeField] private Rigidbody coin;
    [SerializeField] private float spinRate = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, spinRate * Time.deltaTime, 0);
    }
}
