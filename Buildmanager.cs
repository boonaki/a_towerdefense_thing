using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildmanager : MonoBehaviour
{
    public static Buildmanager instance;

    void Awake() //creates a single instance of the build manager so we don't have multiple instances, calling the same objects, resulting in unused copies
    {
        if (instance != null)
        {
            Debug.Log("there is a buildmanager");
            return;
        }
        instance = this;
        

    }



    public GameObject standardturret;
    public GameObject anotherturret;

    public GameObject turretToBuild;
    
    public GameObject getTurretToBuild(GameObject turret) //creates a gameobject to be accessed anywhere
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret) //changes selected turret to what we want to build || CHANGES || changed type from void to gameobject, added return value
    {
        turretToBuild = turret;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
