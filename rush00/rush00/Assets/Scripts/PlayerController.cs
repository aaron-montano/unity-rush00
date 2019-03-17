using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
	public bool	HasGun;
	public GameObject Gun;
    public float direction;
    private float horizontal;
    private float vertical;

    // Start is called before the first frame update

    public Camera cc;
    [HideInInspector]public Transform my;
    private Rigidbody2D body;
	private GameObject tmp;
    void Awake()
    {
		Gun.SetActive(false);
		HasGun = false;
        cc = GameObject.Find("Main Camera").GetComponent<Camera>();
        my = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rotate
        // Vector3 mouse = cc.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        // float angle = Mathf.Atan2(mouse.y - my.position.y, mouse.x - my.position.x) * Mathf.Rad2Deg + 90;
        // body.rotation = angle;
        
		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		diff.Normalize();
 
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
		//movement
		horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
		diff = new Vector3(horizontal * speed, vertical * speed, 0);
        body.velocity = diff;
        //move cam
        cc.transform.position = new Vector3(my.position.x, my.position.y, -10);
		MakeDmg();
		DropGun();
    }
	void MakeDmg()
	{
		if (Input.GetMouseButtonDown(0) && Gun.GetComponent<GunManager>().NumOfBullets > 0)
			Gun.GetComponent<GunManager>().Shoot();
		if (Input.GetMouseButtonDown(0) && Gun.GetComponent<GunManager>().IsMelee)
			Gun.GetComponent<GunManager>().CheckForEnemy = true;
		if (Input.GetMouseButtonUp(0))
			Gun.GetComponent<GunManager>().CheckForEnemy = false;
	}
	void DropGun()
	{
		if (Input.GetMouseButtonDown(1) && HasGun)
		{
			HasGun = false;
			Gun.SetActive(false);
			Gun.GetComponent<GunManager>().CurrentGun.GetComponent<GunPickUp>().NumOfBullets = Gun.GetComponent<GunManager>().NumOfBullets;
			Gun.GetComponent<GunManager>().NumOfBullets = 0;
			Gun.GetComponent<GunManager>().CurrentGun.transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
			Gun.GetComponent<GunManager>().CurrentGun.SetActive(true);
			Gun.GetComponent<GunManager>().CurrentGun = null;
			//add function drop gun forward;
		}
	}
}
