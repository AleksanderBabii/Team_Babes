using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bpInstance;

    [SerializeField]
    private GameObject pooledBullet;
    private bool notEnoughBulletsinPool = true;

    private List<GameObject> bullets = new List<GameObject>();

    private void Awake()
    {
        bpInstance = this;
    }

    public GameObject GetBullet()
    {
        if(bullets.Count > 0)
        {
            for(int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }
        if (notEnoughBulletsinPool)
        {
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
