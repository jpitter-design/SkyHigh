using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MovePlat : MonoBehaviour
{
    public float move = -2; // Move the Platfrom down
    public GameManager start;
    public float delayTime = 4.0f;

     void Start()
    {

        Starts();
    }

    IEnumerator Starts()
    {

        yield return new WaitForSeconds(delayTime);
        start = GetComponent<GameManager>();


    }

    void Update()
    {
        if (start.IsGameActive == true)
        {
            transform.Translate(new Vector3(0, move, 0) * Time.deltaTime);
            if (transform.position.y < -2.8)
            {
                Destroy(gameObject);
            }
        }
    }

}
