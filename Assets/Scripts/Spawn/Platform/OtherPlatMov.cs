using UnityEngine;

public class OtherPlatMov : MonoBehaviour
{

    public float move = -2;
 
    void Update()
    {
        transform.Translate(new Vector3(0, move, 0) * Time.deltaTime);
        if (transform.position.y < -2.8)
        {
            Destroy(gameObject);
        }
    }
}
