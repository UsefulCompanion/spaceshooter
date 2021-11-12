using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Vector2 screenbounds;
    public GameObject projectilePrefab;

    // Awake
    // Start is called before the first frame update
    void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        // IMPORTANT: screenbounds only works with Camera Projection = Orthographic and Camera position x = 0 and y = 0
    }

    // Update is called once per frame
    void Update()
    {
        // Move player depending on input
        Vector2 amtToMove = playerSpeed * new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * Time.deltaTime;

        transform.Translate(amtToMove, Space.World);

        // EXPLANATION: #region lets you specify a block of code that you can expand or collapse when using the outlining feature of your IDE
        // Use the #region and #endregion directives to help organize code blocks. -- see also in Enemy
        #region Screen wrap
        if (transform.position.x < -screenbounds.x)
        {
            // left edge
            transform.position = new Vector3(screenbounds.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > screenbounds.x)
        {
            // right edge
            transform.position = new Vector3(-screenbounds.x, transform.position.y, transform.position.z);
        }
        #endregion

        #region OPTIONAL TASKS : rotation and up/down-movement
        // Stop at upper/lower edge of screen
        if (transform.position.y < -screenbounds.y)
        {
            // upper edge
            transform.position = new Vector3(transform.position.x, -screenbounds.y, transform.position.z);
        }
        if (transform.position.y > screenbounds.y)
        {
            // lower edge
            transform.position = new Vector3(transform.position.x, screenbounds.y, transform.position.z);
        }

        // Rotate cube whilst moving left/right
        // Note: Video that explains what Quaternions are: https://www.youtube.com/watch?v=1yoFjjJRnLY&t=34s
        if (amtToMove.x > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-90, 30, 0), 0.3f);
            //BE CAREFUL, YOUR PLAYER MAY HAVE A DIFFERENT START ROTATION (mine must be -90° in x, yours may be 0° in x)
        }
        else if (amtToMove.x < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-90, -30, 0), 0.3f);
            //BE CAREFUL, YOUR PLAYER MAY HAVE A DIFFERENT START ROTATION (mine must be -90° in x, yours may be 0° in x)
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-90, 0, 0), 0.2f);
            //BE CAREFUL, YOUR PLAYER MAY HAVE A DIFFERENT START ROTATION (mine must be -90° in x, yours may be 0° in x)
        }
        #endregion

        #region fire projectile
        if (Input.GetKeyDown("space"))
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + (0.6f * transform.localScale.y),
                transform.position.z);
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
        #endregion
    }

    // FixedUpdate() 0.02s
    // LateUpdate()
}
