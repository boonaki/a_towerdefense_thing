using System.Collections;
using UnityEngine;
using UnityEngine.iOS;

public class Shop : MonoBehaviour
{
    Buildmanager buildManager;
    //private PlayerInput playerinput;

    //Vector3 movePoint;
    [SerializeField] private GameObject standardturret;
    private GameObject turret_inst;
    
    
    

    void Start()
    {
        buildManager = Buildmanager.instance;
        //playerinput = new PlayerInput();
        
    }


    public void PurchaseStandardTurret()
    {
        Debug.Log("turret purchased");
        turret_inst = Instantiate(standardturret);

        //_turret = buildManager.getTurretToBuild(buildManager.standardturret); //calls build the build manager instance and its functions to create our selected turret
        
    }

    public void PurchaseAnotherTurret()
    {
        Debug.Log("another turret purchased");
    }
    
}
