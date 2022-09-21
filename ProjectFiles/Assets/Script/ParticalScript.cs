using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalScript : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    //private Texture3D _textpre;

    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        //_textpre = GetComponent<Texture3D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_particleSystem.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
