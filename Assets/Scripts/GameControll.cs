using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour
{
    [SerializeField] GameObject player, turret;
    [SerializeField] Transform posses;

    Rigidbody2D playerRb, turretRb;

    bool isPossesed;
    public static bool playerPossesTheTurret;

    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        turretRb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PossesTheTurret()
    {
        if (!isPossesed)
        {
            player.gameObject.SetActive(false);
        }
        if (isPossesed )
        {
            player.gameObject.SetActive(true);
            player.transform.position = new Vector2(posses.position.x, posses.position.y);
        }
    }
}
