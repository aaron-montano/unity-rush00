using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GunPickUP : MonoBehaviour
{
	public PlayerController _playerManager;
	public Sprite GunImage;
	public int	NumOfBullets;
    // Start is called before the first frame update
	void OnTriggerStay2D(Collider2D col)
	{
		if (Input.GetKeyDown("e") && _playerManager.HasGun == false)
		{
			_playerManager.HasGun = true;
			_playerManager.Gun.GetComponent<SpriteRenderer>().sprite = GunImage;
			_playerManager.Gun.SetActive(true);
			Destroy(gameObject);
		}
	}
}
