using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFirePattern1 : MonoBehaviour
{
  
    [SerializeField]
  
    public int bulAmount;

    [SerializeField]

    public float startAngle, endAngle;

    private Vector2 bulletMoveDir;

    private void Start()
    {
        InvokeRepeating("SpawnProjectiles", 0, 2);
        
    }



    // Update is called once per frame
    void Update()
    {
       
    }
    private void SpawnProjectiles()
    {
        float angleStep = (endAngle - startAngle) / bulAmount;
        float angle = startAngle;

        for (int i = 0; i < bulAmount +1; i++)
        {
            //Direction calculations
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) ;
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) ;

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bpInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BulletMovement>().MovementDirection(bulDir);

            
            angle += angleStep;
        }
    }
}
