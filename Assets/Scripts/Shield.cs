using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //When the gameObject collides with another GameObject, Unity calls OnTriggerEnter.
        //other is the Collider of the other GameObject
        if (other.tag == "Enemy") //Make sure your enemy's Tag is "Enemy" !!!
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.SetPositionAndSpeed();

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
        }
    }

}
