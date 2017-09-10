using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGenerator : MonoBehaviour {
    public GameObject redbird;
    int y;
    float delta = 0;
    public float span;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        delta += Time.deltaTime;
        if (delta > span)
        {
            y = Random.Range(-3, 8);
            GameObject bird = Instantiate(redbird) as GameObject;
            bird.transform.position = new Vector2(10.5f, y);
            delta = 0;
        }
    }
}
