using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    /// <summary>
    /// This is the camera controller script 
    /// </summary>
    
    // Camera variables
    [SerializeField] private Camera camera;
    [SerializeField] private Transform player, target;
    [SerializeField] private float camera_speed = 0.1f;
    [SerializeField] private float camera_height = 0.5f;
    [SerializeField] private float camera_width = 0.5f;

    // Logic
    [SerializeField] private Vector3 player_pos, target_pos;



    // Start is called before the first frame update
    void Start()
    {
        // Setting camera size
        camera.orthographicSize = camera_height + camera_width;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get player position
        player_pos = new Vector3(player.position.x, player.position.y, -10);
           
        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -10), player_pos, camera_speed);


        
    }
}
