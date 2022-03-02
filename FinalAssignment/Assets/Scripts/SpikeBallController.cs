using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallController : MonoBehaviour
{
    public Transform center;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center.transform.position, center.transform.up, rotateSpeed * Time.deltaTime);
    }
}
