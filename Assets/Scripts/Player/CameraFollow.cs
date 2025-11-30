using System.Collections;
using System.Linq.Expressions;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float move = 2 ;

   
    void Update()
    {
        transform.Translate(new Vector3(0, move, 0) * Time.deltaTime);
    }
}
