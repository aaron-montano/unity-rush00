using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
	public int NumOfBullets;
	public Sprite Bullet;
	public bool IsMelee;
	public bool CheckForEnemy;
	public GameObject BulletObj;
    // Start is called before the first frame update
    
	void Awake()
	{
        NumOfBullets = 0;
		IsMelee = false;
		CheckForEnemy = false;
	}
	void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && NumOfBullets > 0)
			Shoot();
		if (Input.GetMouseButtonDown(0) && IsMelee)
			CheckForEnemy = true;
		if (Input.GetMouseButtonUp(0))
			CheckForEnemy = false;
    }
	
	void OnCollisionStay2D(Collision2D col)
	{
		//col.gameObject.PlayDeath();
	}
	void Shoot()
	{
		NumOfBullets--;
		Instantiate(BulletObj, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0,0,0)));
	}
}
