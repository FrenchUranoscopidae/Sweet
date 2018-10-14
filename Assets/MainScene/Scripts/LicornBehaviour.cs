using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LicornBehaviour : MonoBehaviour
{
    int count = 0;
    float posY;
    public float direction;
    public GameObject player;
    public float speed;
    float distance;
    public AudioSource licorneSong;
    bool songStart = false;

	void Start ()
    {
        direction = 0.2f;
    }
	
	void Update ()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (count >= 60)
        {
            direction *= -1;
            count = 0;
        }

        //Make the unicorn go up and down.
        posY = transform.position.y;
        transform.Translate(new Vector3(0, posY * direction * Time.deltaTime, 0));

        //Make the unicorn look at the player.
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

        //Make the unicorn go towards the player.
        if (distance <= 10)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), speed * Time.deltaTime);
            
            if(!songStart)
            {
            licorneSong.Play();
            songStart = true;
            }
        }

        count++;
	}


}
