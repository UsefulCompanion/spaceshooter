using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillParticleSystem : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //GetComponent<T>() returns the component of Type T if the game object has one attached, null if it doesn't.
        //IsAlive checks, if the Particle System contains live particles or is still creating new particles
        //Documentation links: 
        //https://docs.unity3d.com/ScriptReference/ParticleSystem.IsAlive.html
        //https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html
        if (!GetComponent<ParticleSystem>().IsAlive()) 
        {
            Destroy(gameObject);
        }
    }
}
