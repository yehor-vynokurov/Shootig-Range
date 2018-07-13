using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeometryObjects;

public class Sphere : Figure {
    public AudioClip blowUpSound;
    override public void Shoot()
    {
        base.Shoot();
        GetComponent<AudioSource>().PlayOneShot(blowUpSound);
        GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(DestroyAfterShoot(blowUpSound.length));
    }
}
