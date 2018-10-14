using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneChanger : MonoBehaviour {

    public GameObject textZone;
    public int index;

    GameObject[] texts;
    public bool id1;
    public bool id2;
    public bool id3;
    public bool id4;
    public bool id5;

    // Use this for initialization
    void Start () {
        texts = new GameObject[textZone.transform.childCount];

        id1 = false;
        id2 = false;
        id3 = false;
        id4 = false;
        id5 = false;

        for (int i=0;i<texts.Length;i++)
        {
            texts[i] = textZone.transform.GetChild(i).gameObject;
        }

        this.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0;i<texts.Length;i++)
        {
            if(i==index)
            {
                texts[i].SetActive(true);
            }
            else
            {
                texts[i].SetActive(false);
            }
            if (i == 1)
            {
                id1 = true;
            }
            if (i == 2)
            {

                id2 = true;
            }
            if (i == 3)
            {

                id3 = true;
            }
            if (i == 4)
            {

                id4 = true;
            }
            if (i == 5)
            {

                id5 = true;
            }
        }

        this.enabled = false;
	}
}
