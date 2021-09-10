using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShoot : TurretShoot_Base
{
    // Start is called before the first frame update
    public GameObject BulletPrefabs;
    public Transform muzzle1;
    public Transform muzzle2;
    public Transform muzzle3;

    public override void Shoot(GameObject go)
    {
        GameObject bulletgo1 = Instantiate(BulletPrefabs, muzzle1.transform.position, muzzle1.transform.rotation);
        GameObject bulletgo2 = Instantiate(BulletPrefabs, muzzle2.transform.position, muzzle2.transform.rotation);
        GameObject bulletgo3 = Instantiate(BulletPrefabs, muzzle3.transform.position, muzzle3.transform.rotation);
    }
}
