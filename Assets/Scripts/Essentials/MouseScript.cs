using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //FixedUpdate happens every 0.02 seconds, not every frame!
    public void FixedUpdate()
    {
        Ray myray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(myray, out hit, Mathf.Infinity,layerMask))

        {
            transform.position = hit.point;
            //transform.position = Vector3.Lerp(transform.position, hit.point, 0.1f); This is mousetracking with 0.1 delay
            
            /* if(Input.GetButtonDown("Fire1") && hit.transform.CompareTag("Enemy")) This is for destroy object you click on!
            {
                //Destroy(hit.transform.gameObject);
            } */
        }

        
    
    }
}
