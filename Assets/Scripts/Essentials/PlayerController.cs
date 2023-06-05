using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Game Mode")]
    public bool controller = false;
    public bool mouseAndKeyboard = false;
    

    [Header ("Player Movement")]
    [Range (0.1f,30f)]
    public float playerSpeed = 10f;
    public float hor;
    public float ver;

    [Header ("Shooting")]
    public GameObject bullet;
    public Transform gun1;
    public Transform gun2;
    public float fireRate = 0.5f;
    public bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        if (controller)
        {
            gun1.GetComponent<TwinStickAim>().enabled = true;
            gun1.GetComponent<GunScript>().enabled = false;
            gun2.GetComponent<TwinStickAim>().enabled = true;
            gun2.GetComponent<GunScript>().enabled = false;
        }
        else
        {
            gun1.GetComponent<TwinStickAim>().enabled = false;
            gun1.GetComponent<GunScript>().enabled = true;
            gun2.GetComponent<TwinStickAim>().enabled = false;
            gun2.GetComponent<GunScript>().enabled = true;
        }
    
    
    }


    // Update is called once per frame
    void Update()
    {
        //This moves player on axis x and y with button inputs
        
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(hor*playerSpeed*Time.deltaTime,0*Time.deltaTime,0));


        if (transform.position.x <= -19)
        {
            transform.position = new Vector3(-19, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= 16)
        {
            transform.position = new Vector3(16, transform.position.y, transform.position.z);
        }





        //This is for shooting

        if (!controller && Input.GetButton("Fire1") &&canFire)
        {
            StartCoroutine("Shoot");
        }
    }

    public IEnumerator Shoot()
    {
        Instantiate(bullet, gun1.position, gun1.rotation);
        Instantiate(bullet, gun2.position, gun2.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
