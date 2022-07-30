using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHazard : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 endPoint;
    
    

   // private Vector3 startPoint = new Vector3(0, 0, 0);

   // private Vector3 endPoint = new Vector3(0, 5, 0);
    // Start is called before the first frame update

    private void Update()
    {
        transform.position = Vector3.Lerp(startPoint, endPoint, Mathf.PingPong(Time.time * speed, 1));
    }
} 