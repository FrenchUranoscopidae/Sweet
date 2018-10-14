using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Inventory : MonoBehaviour {

    public GameObject[] number;
    public GameObject[] weapon;
    int index;
    float counter;
    public GameObject currentWeapon;
    
    void Start()
    {
        index = 0;
        counter = 0;
    }

	void Update ()
    {
        counter += Time.deltaTime;
        if (Input.mouseScrollDelta.y > 0 && counter >= 0.1f)
        {
            index++;
            counter = 0;
            if (index > number.Length - 1)
                index = 0;
        }

        if (Input.GetButtonDown("RB"))
        {
            index++;
            counter = 0;
            if (index > number.Length - 1)
                index = 0;
        }

        if (Input.mouseScrollDelta.y < 0 && counter >= 0.1f)
        {
            index--;
            counter = 0;
            if (index < 0)
                index = number.Length-1;
        }

        if (Input.GetButtonDown("LB"))
        {
            index--;
            counter = 0;
            if (index < 0)
                index = number.Length - 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            index = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            index = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            index = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            index = 3;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            index = 4;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            index = 5;
        }

        for (int i = 0; i < number.Length; i++)
        {
            if (i != index)
            {
                number[i].transform.GetChild(0).gameObject.SetActive(true);
                number[i].transform.GetChild(1).gameObject.SetActive(false);
                weapon[i].transform.gameObject.SetActive(false);
            }
            else
            {
                number[i].transform.GetChild(0).gameObject.SetActive(false);
                number[i].transform.GetChild(1).gameObject.SetActive(true);

                if (FindObjectOfType<FirstPersonController>().GetComponent<BreakTrees>().canEquipSword == true && i == 0)
                {
                    weapon[i].transform.gameObject.SetActive(true);
                    currentWeapon = weapon[i].transform.gameObject;
                }

                if (FindObjectOfType<FirstPersonController>().GetComponent<BreakTrees>().canEquipAxe == true && i == 1)
                {
                    weapon[i].transform.gameObject.SetActive(true);
                    currentWeapon = weapon[i].transform.gameObject;
                }
            }
        }
    }
}