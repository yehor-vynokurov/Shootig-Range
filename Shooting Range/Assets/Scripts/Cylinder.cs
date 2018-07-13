using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeometryObjects;

public class Cylinder : Figure {
    public AnimationClip cylinderClip;
    public override void Shoot()
    {
        base.Shoot();
        GetComponent<Animator>().SetTrigger("Shoot");
        StartCoroutine(DestroyAfterShoot(cylinderClip.length));
    }
}
