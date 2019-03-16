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
        cc = GetComponent<Camera>();
        my = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        //movement
        /* if (  (direction = Input.GetAxis("Horizontal")) != 0f)
            body.velocity = direction * cc.transform.right * speed;
            //transform.Translate(cc.transform.left * direction * speed * Time.deltaTime, Space.World);
        if ( (direction = Input.GetAxis("Vertical")) != 0f)
            body.velocity = direction * cc.transform.up * speed;
            //transform.Translate(cc.transform.down * direction * speed * Time.deltaTime, Space.World);
        */
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
        //rotation
        float camDis = transform.position.y - my.position.y;
        Vector3 mouse = cc.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));
        float AngleRad = Mathf.Atan2(mouse.y - my.position.y, mouse.x - my.position.x);
        float angle = 90 + (180 / Mathf.PI) * AngleRad;
        my.rotation = Quaternion.Euler(0, 0, angle);
    }
}
