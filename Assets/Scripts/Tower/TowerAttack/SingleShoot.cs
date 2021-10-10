using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShoot : TurretShoot_Base
{
    public GameObject BulletPrefabs;
    public Transform muzzle;

    public override void Shoot(GameObject go)
    {
        GameObject bulletgo = Instantiate(BulletPrefabs, muzzle.transform.position, muzzle.transform.rotation);
        
    }
   
}
