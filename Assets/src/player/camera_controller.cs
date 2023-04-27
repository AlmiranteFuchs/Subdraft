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
    [SerializeField] private Transform player;
    [SerializeField] private float camera_speed = 0.1f;
    [SerializeField] private float camera_offset = 0.5f;
    [SerializeField] private float camera_height = 0.5f;
    [SerializeField] private float camera_width = 0.5f;


    // Logic
    [SerializeField] private Vector3 camera_position;
    [SerializeField] private Vector3 player_position;
    [SerializeField] private Vector3 camera_velocity;
    [SerializeField] private Vector3 player_velocity;

    // Start is called before the first frame update
    void Start()
    {
        // Setting camera position
        camera_position = camera.transform.position;
        camera_position.x = player.position.x + camera_offset;
        camera_position.y = player.position.y + camera_offset;
        camera_position.z = -10f;
        camera.transform.position = camera_position;

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Getting player position
        player_position = player.position;
        player_velocity = player.GetComponent<Rigidbody2D>().velocity;

        // Getting camera position
        camera_position = camera.transform.position;
        camera_velocity = camera_velocity * camera_speed;

        // Setting camera position
        camera_position.x = player_position.x + camera_offset;
        camera_position.y = player_position.y + camera_offset;
        camera_position.z = -10f;

        // Setting camera velocity
        camera_velocity.x = player_velocity.x * camera_speed;
        camera_velocity.y = player_velocity.y * camera_speed;

        // Setting camera position
        camera.transform.position = camera_position;
        camera.transform.position = Vector3.SmoothDamp(camera.transform.position, camera_position, ref camera_velocity, camera_speed);

        // Setting camera size
        camera.orthographicSize = camera_height + camera_width;



        
    }
}
