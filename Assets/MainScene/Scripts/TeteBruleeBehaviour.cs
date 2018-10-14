using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeteBruleeBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject particle;
    Rigidbody rb;

	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= 4 && distance >= 1)
        {
            rb.AddForce(new Vector3(0, 10, 0));
        }

        if (distance <= 10)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), 1 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Explode();
        }
    }

    void Explode()
    {
        ParticleSystem particleSystem = particle.GetComponent<ParticleSystem>();
        particleSystem.Play();
        Destroy(gameObject, particleSystem.main.duration - 1.0f);
    }
}