using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // EXPLANATION: #region lets you specify a block of code that you can expand or collapse when using the outlining feature of your IDE
    // Use the #region and #endregion directives to help organize code blocks.
    #region Fields
    public float minSpeed, maxSpeed;
    private float currentSpeed;
    private float x, y, z;
    private Vector2 screenbounds;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        SetPositionAndSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        // movement
        float amtToMove = currentSpeed * Time.deltaTime;
        transform.Translate(Vector3.down * amtToMove);

        if (transform.position.y <= -screenbounds.y * 1.3f)
        {
            SetPositionAndSpeed();
        }
    }

    public void SetPositionAndSpeed()
    {
        //Enemy ist teleported to the upper edge of the screen
        currentSpeed = Random.Range(minSpeed, maxSpeed);

        x = Random.Range(-screenbounds.x, screenbounds.x);
        y = screenbounds.y * 1.3f;
        z = 0;
        transform.position = new Vector3(x, y, z);
    }
}
