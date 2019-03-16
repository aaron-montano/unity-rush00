using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float direction;
    private float horizontal;
    private float vertical;

    // Start is called before the first frame update

    public Camera cc;
    private Transform my;
    private Rigidbody2D body;

    void Awake()
    {
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
        Vector3 mouse = cc.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        float angle = Mathf.Atan2(mouse.y - my.position.y, mouse.x - my.position.x) * Mathf.Rad2Deg + 90;
        body.rotation = angle;

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        //movement
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
        //move cam
        cc.transform.position = new Vector3(my.position.x, my.position.y, -10);
    }
}
