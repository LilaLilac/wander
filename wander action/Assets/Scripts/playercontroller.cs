using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour {

    Rigidbody2D rigid2D;
    public float jumpForce;
    public float walkForce;
    float maxWalkSpeed = 4f;
    Animator animator;
    public GameObject pulse;
    public LayerMask map;
    bool isGrounded;
    float jumpKey;

    // Use this for initialization
    void Start () {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        jumpKey = 0;
	}
	
	// Update is called once per frame
	void Update () {
        isGrounded = Physics2D.Linecast(
            transform.position + transform.up * 1,
            transform.position - transform.up * 1,
            map);
        //ジャンプ

        if (isGrounded && Input.GetKey(KeyCode.LeftShift)&&jumpKey<20)
        {
            ++jumpKey;
        }

        if (jumpKey>0&&isGrounded&&Input.GetKeyUp(KeyCode.LeftShift))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce*this.jumpKey);
            isGrounded = false;
            jumpKey = 0;
        }
        //左右移動

            int key = 0;
            if (Input.GetKey(KeyCode.RightArrow)) key = 1;
            if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

            float speedx = Mathf.Abs(this.rigid2D.velocity.x);

            if (speedx < this.maxWalkSpeed)
            {
                this.rigid2D.AddForce(transform.right * key * this.walkForce);
            }
            if (key != 0)
            {
                transform.localScale = new Vector3(key, 1, 1);
            }

            this.animator.speed = speedx / 5f;
      
        

        //発射
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bullet = Instantiate(pulse) as GameObject;
            bullet.transform.position =new Vector2( this.transform.position.x+this.transform.localScale.x, this.transform.position.y);
        }
	}
}
