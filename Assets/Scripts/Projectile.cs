using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    private Vector2 screenbounds;

    public GameObject explosionPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        float amtToMove = projectileSpeed * Time.deltaTime;
        transform.Translate(Vector3.up * amtToMove);

        if (transform.position.y > screenbounds.y * 1.2f)
        {
            Destroy(gameObject);
        }
    }

    /*private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }*/

    private void OnTriggerEnter(Collider other)
    {
        //When the gameObject collides with another GameObject, Unity calls OnTriggerEnter.
        //other is the Collider of the other GameObject
        if (other.tag == "Enemy") //Make sure your enemy's Tag is "Enemy" !!!
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.SetPositionAndSpeed();

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Player.score += 100;
            Player.UpdateStats();
            
            Destroy(gameObject);
        }
    }
}
