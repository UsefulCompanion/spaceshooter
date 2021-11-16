using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioClip boom;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(boom, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
