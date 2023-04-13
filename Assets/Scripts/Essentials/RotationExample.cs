using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationExample : MonoBehaviour
{
    [Range (1f , 100f)]
    public float rotateSpeed = 50f;
    [Range (1f , 100f)]
    public float drivingSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * ver * drivingSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, hor * rotateSpeed * Time.deltaTime);
    }

}
