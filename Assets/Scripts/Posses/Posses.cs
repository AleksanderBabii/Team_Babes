using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posses : MonoBehaviour
{
    public Transform turret;
    public Transform player; 
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            GameControll.playerPossesTheTurret = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            GameControll.playerPossesTheTurret = false;
        }
    }
}
