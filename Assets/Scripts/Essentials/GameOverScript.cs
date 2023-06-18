using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class GameOverScript : MonoBehaviour
{
    public bool dead = false;

    public GameObject gameOverMenu;
    public GameObject player;
    


    // Start is called before the first frame update
    void Start()
    {
        
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Button to toggle pause boolean
        if (GameObject.Find("Player") == null)
        {
            
            gameOverMenu.SetActive(true);
            
            


        }
        





        



    }
}