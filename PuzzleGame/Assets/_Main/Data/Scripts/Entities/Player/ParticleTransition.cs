using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTransition : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;

    public void PlayEffect() => _particles.Play();

    public void StopEffect() => _particles.Stop();

}
