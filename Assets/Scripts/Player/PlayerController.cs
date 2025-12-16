using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed =  15f;
    private float jumpForce = 8;

    private Rigidbody PlayerRb;


    public GameManager start;
    public float delayTime = 1.0f;

    private void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        Starts();

    }
    // Update is called once per frame
    IEnumerator Starts()
    {

        yield return new WaitForSeconds(delayTime);
        start = GetComponent<GameManager>();


    }
    void Update()
    {
        //start.StartGame();

        //if (!start.IsGameActive == false)
        if (start.IsGameActive == true)
        {
            {
                PlayerRb.useGravity = true;
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
                }

                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
                }
            }
            if (transform.position.y < -3.2)
            {
                //start.GameOver();
                Destroy(gameObject);

            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Platform"))
        {
            PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
