using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    ParticleSystem particles;
    [SerializeField] public float size = 2f;

    private ParticleSystem.MainModule particlesMain;

    private void Awake(){
        particles = GetComponent<ParticleSystem>();
        particlesMain = particles.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        particlesMain.startSize = new ParticleSystem.MinMaxCurve(size, size + 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(particles.isStopped){
            Destroy(gameObject);
        }
    }
}
