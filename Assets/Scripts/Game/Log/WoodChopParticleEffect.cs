using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodChopParticleEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject  particleSystemPrefab;
    [SerializeField]
    private Transform   positionToSpawn;

    private void Start()
    {
        // Spawns wooden particles every time knife hits the log
        HitEvent.KnifeLanded += PlayParticleSystem;
    }

    public void PlayParticleSystem()
    {
        GameObject newParticleSystem = Instantiate(particleSystemPrefab);
        newParticleSystem.transform.position = positionToSpawn.position;
    }

    private void OnDestroy()
    {
        HitEvent.KnifeLanded -= PlayParticleSystem;
    }
}
