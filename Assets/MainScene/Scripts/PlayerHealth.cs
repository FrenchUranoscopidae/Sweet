using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerLife;
    public GameObject respawn;
    public GameObject redPlane;
    Image image;
    public GameObject state1;
    public GameObject state2;
    public GameObject state3;
    public TextMeshProUGUI healthtext;
    public TextMeshProUGUI timertext;
    int count;
    Color tempColor;
    GameObject BeginningText;
    public GameObject InteractText;
    Inventory inventory;
    float minut;
    float second;
    bool timerstart;
    public GameObject Island1;
    public GameObject Island2;
    public GameObject Island3;
    public GameObject Island4;
    public GameObject Island5;
    bool trigger1;
    bool trigger2;
    bool trigger3;
    bool trigger4;
    bool trigger5;
    Rigidbody rb;


    // Use this for initialization
    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        playerLife = 6;
        image = redPlane.GetComponent<Image>();
        tempColor = image.color;
        BeginningText = GameObject.Find("Beginning");
        inventory = FindObjectOfType<Inventory>();
        timerstart = false;
        minut = 14;
        second = 59;
        trigger1 = false;
        trigger2 = false;
        trigger3 = false;
        trigger4 = false;
        trigger5 = false;
    }

    // Update is called once per frame
    void Update()
    {
        second -= Time.deltaTime;
        if (second < 0)
        {
            minut--;
            second = 59;
        }

        if (minut < 0)
        {
            GameOver();
        }

        if ((Island1.GetComponent<ZoneChanger>().id1 == true) && (trigger1 = false))
        {
            minut = minut + 2;
            trigger1 = true;
        }
        if ((Island2.GetComponent<ZoneChanger>().id2 == true) && (trigger2 = false))
        {
            minut = minut + 2;
            trigger2 = true;
        }
        if ((Island3.GetComponent<ZoneChanger>().id3 == true) && (trigger3 = false))
        {
            minut = minut + 2;
            trigger3 = true;
        }
        if ((Island4.GetComponent<ZoneChanger>().id4 == true) && (trigger4 = false))
        {
            minut = minut + 2;
            trigger4 = true;
        }
        if ((Island5.GetComponent<ZoneChanger>().id5 == true) && (trigger5 = false))
        {
            minut = minut + 2;
            trigger5 = true;
        }
        else
        {
            timertext.text = "05 : 00";
        }

        tempColor.a = tempColor.a - 0.01f;
        healthtext.text = playerLife + "/6";
        image.color = tempColor;
        timertext.text = "0" + minut + " : " + (int) second;


        if (minut < 0)
        {
            GameOver();
        }

        if (playerLife >= 3 && playerLife <= 5)
        {
            state1.SetActive(false);
            state2.SetActive(true);
        }

        if (playerLife >= 1 && playerLife <= 2)
        {
            state2.SetActive(false);
            state3.SetActive(true);
        }

        if (playerLife == 0)
        {
            GameOver();
        }
        count++;

        //Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0f));
        RaycastHit hit;
        // Physics.Raycast(ray, out hit)
        if (Physics.Raycast(transform.position, transform.forward * 2f, out hit) && hit.transform.gameObject.tag == "Box" && inventory.currentWeapon.GetComponent<WeaponHandler>().unicornLeg) //Nom de l'arme dans l'inventory, bool dans le weapon handler
        {
            float distance = Vector3.Distance(transform.position, hit.transform.gameObject.transform.position);
            if (distance <= 2f) InteractText.SetActive(true);
            else InteractText.SetActive(false);
        }
        else
        {
            InteractText.SetActive(false);
        }
    }
    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (count >= 60)
        {
            if (col.gameObject.tag == "Enemy")
            {
                playerLife--;
                count = 0;
                tempColor.a = 0.75f;
            }
        }

        if (col.gameObject.tag == "Lake")
        {
            GameOver();
        }

        if(col.gameObject.tag == "damageZone")
        {
            transform.position = respawn.transform.position;
            playerLife --;
        }

        if(col.gameObject.tag=="Island")
        {
            col.collider.GetComponent<ZoneChanger>().enabled = true;
            BeginningText.SetActive(false);
        }

        if (col.gameObject.tag == "jelly")
        {
            Debug.Log("jump");
            rb.AddForce(0, 100, 0);
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver_Scene");
    }
}

//PAS DE MAJUSCULES AUX VARIABLE KLUGIULHKYUFIOULHGUIOL