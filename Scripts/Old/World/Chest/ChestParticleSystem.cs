using System;
using System.Collections.Generic;
using UnityEngine;

public class ChestParticleSystem : MonoBehaviour
{
    [NonSerialized] public ParticleSystem particles;
    [NonSerialized] public ParticleSystem.EmissionModule emis;
    private void Start()
    {
        particles = transform.GetComponent<ParticleSystem>();
        emis = particles.emission;

      
    }

    
    
}
