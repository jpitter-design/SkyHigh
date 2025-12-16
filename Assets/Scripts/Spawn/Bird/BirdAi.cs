using UnityEngine;

public class BirdAi : MonoBehaviour
{
    public GameObject Bird;
    public float move; // Move the bird right
    public float PushPower = 10;
    void Start()
    {

    }
    void Update()
    {
            if (transform.position.x < 15)
        {
            transform.Translate(new Vector3(move, 0, 0) * Time.deltaTime);
        }
       //else  if (transform.position.x > -10)
       // {
       //     transform.Translate(new Vector3(-move, 0, 0) * Time.deltaTime);
       // }
       if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Get player rigidbody 
           Rigidbody PlayerRb = collision.gameObject.GetComponent<Rigidbody>();
           Destroy(gameObject);
            if (transform.position.x > 0)
            {
                PlayerRb.AddForce(Vector3.left * 10, ForceMode.Impulse);
            }
            if (transform.position.x < 0)
            {
                PlayerRb.AddForce(Vector3.right * 10, ForceMode.Impulse);
            }

        }
    }
}
