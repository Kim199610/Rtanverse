using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameDustControle : MonoBehaviour
{
    private bool creatDustOnJump = true;
    [SerializeField] private ParticleSystem dustParticleSystem;
    
    public void CreatDustParticles()
    {
        if (creatDustOnJump)
        {
            dustParticleSystem.Stop();
            dustParticleSystem.Play();
        }
    }
}
