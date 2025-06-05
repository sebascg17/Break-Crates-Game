using UnityEngine;

public class Targets : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;

    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10f;
    private float xRange = 4f;
    private float ySpawnPos = -6f;

    public ParticleSystem explosionParticle;
    public int pointValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown ()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter ( Collider other )
    {
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        Destroy(gameObject);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
