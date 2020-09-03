using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMaker : MonoBehaviour
{
    Collider NoiseCollider;
    public GameObject NoiseParticle;
    public GameObject NoiseParticleArea;
    Transform noisemakerTransform;


    void Start()
    {
        NoiseCollider = GetComponent<Collider>();
        NoiseParticle.SetActive(false);
        NoiseParticleArea.SetActive(false);
        MakeNoise();
    }

    public void MakeNoise()
    {
        NoiseCollider.enabled = true;
        NoiseParticle.SetActive(true);
        NoiseParticleArea.SetActive(true);

    }
    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1);
    }
}
