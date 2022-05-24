using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFirePattern2 : MonoBehaviour
{
    private float angle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnProjectile", 0f,0.1f);
    }
    private void SpawnProjectile()
    {
        float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180);
        float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

        GameObject bul = BulletPool.bpInstance.GetBullet();
        bul.transform.position = transform.position;
        bul.transform.rotation = transform.rotation;
        bul.SetActive(true);
        bul.GetComponent<BulletMovement>().MovementDirection(bulDir);


        angle += 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
