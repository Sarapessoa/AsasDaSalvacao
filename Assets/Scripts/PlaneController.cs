using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{   

    public float resonsiveness = 10f;
    [SerializeField] GameObject explosionPrefab;

    private ParticleSystem particlesExplosion;

    public GameObject bulletPrefab;
    public Transform[] firePoints;
    private GameObject planeBreak;
    private GameObject planeDefault;

    private float throttle = 105000f;
    private float roll;
    private float pitch;
    private float yaw;
    private bool isPlaying = true;

    private float responseModifier {
        get {
            return (rb.mass / 10f) * resonsiveness;
        }
    }

    Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void Start(){
        planeBreak = transform.Find("break_jet").gameObject;
        planeDefault = transform.Find("default").gameObject;
    }

    private void Update(){
        if(!isPlaying) return;

        HandleInputs();
        ApplyForces();
    }
    
    private void HandleInputs(){
        // Rotação para direita ou esquerda
        roll = Input.GetAxis("Roll");
        // Rotação para cima ou baixo
        pitch = Input.GetAxis("Pitch");
        // Movimento para os lados
        yaw = Input.GetAxis("Yaw");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Chama o método para disparar
            Shoot();
        }
    }

    private void ApplyForces()
    {
        // Calcula as forças baseadas nos inputs de rotação
        Vector3 torque = new Vector3(-pitch*6.0f, yaw*5.5f , -roll*3.5f) * responseModifier;
        rb.AddRelativeTorque(torque);

        // Aplica uma força com base no throttle
        rb.AddRelativeForce(Vector3.forward * throttle);
    }

     void Shoot()
    {
        foreach (Transform firePoint in firePoints)
        {
            // Instancia uma nova bala no ponto de origem do disparo
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.bulletDirection = transform.forward;        
        }
    }

    void OnCollisionEnter(Collision collision){

        if (collision.gameObject.name == "Terrain" && isPlaying){
            startExplosion();
            stopPlane();
        }
    }

    void startExplosion(){
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        particlesExplosion = explosion.GetComponent<ParticleSystem>();
        Explosion explosionScript = explosion.GetComponent<Explosion>();
        explosionScript.size = 25f;
    }

    void stopPlane(){
        planeBreak.SetActive(true);
        planeDefault.SetActive(false);
        isPlaying = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

}
