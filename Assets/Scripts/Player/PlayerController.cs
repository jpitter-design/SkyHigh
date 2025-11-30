using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public float speed =  0f;
    public float jump = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player") && CompareTag("Platform"))
        {

        }
    }
}
