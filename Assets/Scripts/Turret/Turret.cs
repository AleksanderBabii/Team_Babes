using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Vector2 mousePos;

    public Camera cam;
    public Rigidbody2D rb;

    [SerializeField]

    public int bulAmount;

    [SerializeField]

    public float startAngle, endAngle;

    private Vector2 bulletMoveDir;


    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnProjectiles();
        }

    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    public void SpawnProjectiles()
    {
        float angleStep = (endAngle - startAngle) / bulAmount;
        float angle = startAngle;

        for (int i = 0; i < bulAmount + 1; i++)
        {
            //Direction calculations
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180);

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
