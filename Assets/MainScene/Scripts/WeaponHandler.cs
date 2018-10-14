using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
	public int damages;
    public int range;
    public int rate;
    public AudioSource coupJoueur;
    public GameObject player;
    public Camera cam;
    int count;
    public bool unicornLeg;
    public GameObject leg;
    public GameObject pont;


	void Start ()
    {
		count = 0;
        unicornLeg = false;
	}

    void Update()
    {
        count++;
        
        if (count >= rate)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Enemy")
                {
                    float distance = Vector3.Distance(player.transform.position, hit.transform.position);

                    if (distance <= range)
                    {
                        coupJoueur.Play();
                        if (hit.transform.gameObject.name == "Licorne")
                        {
                            if (hit.transform.gameObject.GetComponent<Health>().health <= 1)
                            {
                                unicornLeg = true;
                                leg.gameObject.SetActive(true);
                            }
                        }
                        hit.transform.gameObject.GetComponent<Health>().health -= damages;
                    }
                }
                count = 0;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Box" && unicornLeg == true)
                {
                    unicornLeg = false;
                    pont.gameObject.SetActive(true);
                    leg.gameObject.SetActive(false);
                }
            }
        }
    }
}
