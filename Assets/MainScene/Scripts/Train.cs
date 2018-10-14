using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Train : MonoBehaviour
{
    float offset_y;
    public GameObject player;
    public GameObject wagon1;
    public GameObject wagon2;
    public GameObject loco;
    public float speed;

	void Start ()
    {
        offset_y = loco.transform.position.y - GameObject.Find("Flottante_1(1)").transform.position.y;
    }

	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        loco.transform.rotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, offset_y, player.transform.position.z));
        wagon1.transform.rotation = Quaternion.LookRotation(new Vector3(loco.transform.position.x, offset_y, loco.transform.position.z));
    }
}
