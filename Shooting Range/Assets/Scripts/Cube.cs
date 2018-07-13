using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeometryObjects;

public class Cube : Figure {
    public GameObject explosionEffect;

    public override void Shoot()
    {
        base.Shoot();
        GameObject tempParticle = Instantiate(explosionEffect, transform.position, transform.rotation);
        tempParticle.transform.SetParent(transform);
        GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(DestroyAfterShoot(explosionEffect.GetComponent<ParticleSystem>().main.duration));
    }
}
