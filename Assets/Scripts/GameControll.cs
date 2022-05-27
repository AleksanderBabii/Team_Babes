using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour
{
    public GameObject[] turrets;
    [SerializeField]

    GameObject currentTurret;
    

    
    
    void Start()
    {
       for (int i = 1; i < turrets.Length; i++)
       {
            turrets[i].GetComponent<Turret>().enabled = false;  
       }
        currentTurret = turrets[0];
        
    }

    public void ChangeTurret(GameObject turret)
    {
        currentTurret.GetComponent<Turret>().enabled = false;
        currentTurret = turret;
    }
  
   
}
