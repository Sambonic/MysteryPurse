using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController4 : MonoBehaviour
{
    public GameObject player;
    public float offset; //offset the position of the camera
    public float offsetSmoothing; //smooth the motion of the camera
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z); //updates the camera position of the player (x changes only)(if you want on th y axis also put player.(rest of code) in the second parameter) //this code can be used alone
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);//to make the camera look more to the right when moving to the right
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);//to make the camera look more to the left when moving left
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);//specify how quickly the camera catches up with the player and how smoothley
        //--------------
        float playerVerticalPosition = player.transform.position.y;
        float cameraVerticalPosition = transform.position.y;

        float verticalOffset = Mathf.Clamp(playerVerticalPosition - cameraVerticalPosition, -offset, offset);
        transform.position += new Vector3(0f, verticalOffset, 0f);
    }
}
