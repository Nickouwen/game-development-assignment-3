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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("Player"))
        {
            GameManager.instance.AddScore(1);
            Destroy(coin.gameObject);
        }
    }
}
