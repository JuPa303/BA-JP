using UnityEngine;
using System.Collections;

public class Bullet_Detonation : MonoBehaviour {

    float lifespan = 3.0f;

    public GameObject fireEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lifespan -= Time.deltaTime;

        if(lifespan <=0){
            explode();
        }
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.tag = "Untagged";
            Instantiate(fireEffect, collider.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

   void explode() {
       Destroy(gameObject);
}
}
