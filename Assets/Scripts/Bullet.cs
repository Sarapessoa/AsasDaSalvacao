using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject explosionPrefab;

    private ParticleSystem particlesExplosion;
    private ParticleSystem particlesSmoke;
    private Transform objectBullet;
    private GameObject missileBreak;
    private bool explosionActive = false;

    public float bulletForce = 190000f;
    public Vector3 bulletDirection = Vector3.forward; // Direção padrão: para frente

    private void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    void Start(){
        particlesSmoke = transform.Find("Smoke").gameObject.GetComponent<ParticleSystem>();

        objectBullet = transform.Find("ObjectMissile");

        missileBreak = transform.Find("break_missile").gameObject;

        rb.AddForce(bulletDirection.normalized * bulletForce, ForceMode.Impulse);
        var accumulatedForce = rb.GetAccumulatedForce();
    }

    void FixedUpdate(){

    }

    void Update(){    
        if(explosionActive && particlesExplosion == null && !particlesSmoke.isPlaying){
            Destroy(gameObject);
        }
    }

    void startExplosion(){
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        particlesExplosion = explosion.GetComponent<ParticleSystem>();
        explosionActive = true;
    }

    void monityParticlesExplosion(){
    }

    void OnCollisionEnter(Collision collision){

        if (collision.gameObject.name == "Terrain"){
            rb.isKinematic = true;
            startExplosion();
            particlesSmoke.Stop();
            objectBullet.gameObject.SetActive(false);
            missileBreak.SetActive(true);
        }
    }

}
