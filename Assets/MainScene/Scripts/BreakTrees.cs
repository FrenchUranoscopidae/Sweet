using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BreakTrees : MonoBehaviour
{
    int range;
    public bool canEquipSword;
    public bool canEquipAxe;
    bool pickedUpTree;
    bool pickedUpAlmond;
    public Camera cam;
    public GameObject swordSprite;
    public GameObject axeSprite;
    public Text useWeapon;
    public Text useAxe;
    Color tempColorA;
    Color tempColorB;

	
	void Start ()
    {
        range = 3;
        canEquipSword = false;
        canEquipAxe = false;
        tempColorA = useAxe.color;
        tempColorB = useWeapon.color;
	}
	
	void Update ()
    {
        tempColorA.a -= 0.005f;
        tempColorB.a -= 0.005f;
        useAxe.color = tempColorA;
        useWeapon.color = tempColorB;

        if(pickedUpAlmond && pickedUpTree)
        {
            canEquipAxe = true;
            axeSprite.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                float distance = Vector3.Distance(transform.position, hit.transform.position);

                if (distance <= range)
                {
                    if (hit.transform.gameObject.tag == "liquoriceTree")
                    {
                        canEquipSword = true;
                        Destroy(hit.transform.gameObject);
                        swordSprite.SetActive(true);
                    }

                    if (hit.transform.gameObject.tag == "liquoriceTree2")
                    {
                        pickedUpTree = true;
                        Destroy(hit.transform.gameObject);
                    }

                    if (hit.transform.gameObject.tag == "almond")
                    {
                        pickedUpAlmond = true;
                        Destroy(hit.transform.gameObject);
                    }

                    if (hit.transform.gameObject.tag == "murArbre")
                    {
                        if (canEquipAxe)
                        {
                            Destroy(hit.transform.gameObject);
                        }
                        else
                        {
                            tempColorA.a = 1;
                        }
                    }

                    if(hit.transform.gameObject.tag == "Enemy" && canEquipSword == false)
                    {
                        tempColorB.a = 1;
                    }

                    if(hit.transform.gameObject.tag == "end")
                    {
                        SceneManager.LoadScene("MainMenu_Scene");
                    }
                }
            }
        }
    }
}
