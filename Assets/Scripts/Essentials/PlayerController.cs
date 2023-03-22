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
    public Transform gun;
    public float fireRate = 0.5f;
    public bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        if (controller)
        {
            gun.GetComponent<TwinStickAim>().enabled = true;
            gun.GetComponent<GunScript>().enabled = false;
        }
        else
        {
            gun.GetComponent<TwinStickAim>().enabled = false;
            gun.GetComponent<GunScript>().enabled = true;
        }
    
    
    }


    // Update is called once per frame
    void Update()
    {
        //This moves player on axis x and y with button inputs
        
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(hor*playerSpeed*Time.deltaTime,ver*playerSpeed*Time.deltaTime,0));

        //This is for shooting

        if (!controller && Input.GetButton("Fire1") &&canFire)
        {
            StartCoroutine("Shoot");
        }
    }

    public IEnumerator Shoot()
    {
        Instantiate(bullet, gun.position, gun.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
