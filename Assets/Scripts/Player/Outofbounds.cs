using UnityEngine;

public class Playerlmit : MonoBehaviour
{

    public float leftBound = -7.09f;
    public float rightBound = 10f; 
    // Limt the player from moving out of bounds


    void Update()
    {
        if (transform.position.x < leftBound)
        {
            transform.position = new Vector3(leftBound,transform.position.y,transform.position.z);
        }
        if (transform.position.x > rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }
    }
}
