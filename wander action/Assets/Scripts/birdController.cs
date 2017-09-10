using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdController : MonoBehaviour {

    Rigidbody2D rigid2D;
    public float speed;
    Animator animator;

    // Use this for initialization
    void Start () {
        Vector2 fly = new Vector2(speed*-1, 0);
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.rigid2D.AddForce(fly);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D pulse)
    {
        if (pulse.gameObject.tag == "pulse")
        {
            this.animator.SetTrigger("Stan");
            this.rigid2D.velocity = new Vector2(0,0);
            Destroy(this.gameObject, 1);
        }
    }
}
