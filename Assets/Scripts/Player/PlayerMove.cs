using UnityEngine;

public class PlayerMove 
{
    GameObject player;
    Rigidbody2D playerRigidbody;
    float accelerationSpeed;
    float maxSpeed;
    float rotSpeed;

    public PlayerMove(GameObject player,float accelerationSpeed,float rotSpeed, float maxSpeed)
    {
        this.player = player;
        this.accelerationSpeed = accelerationSpeed;
        this.rotSpeed = rotSpeed;
        this.maxSpeed = maxSpeed;
        playerRigidbody = player.GetComponent<Rigidbody2D>();
    }
    public void Forward()
    {
        if(playerRigidbody.velocity.magnitude < maxSpeed)
        {
            playerRigidbody.AddRelativeForce(Vector2.up * accelerationSpeed * Time.fixedDeltaTime);
        } 
    }
    public void RotLeft()
    {
        player.transform.Rotate(new Vector3(0f,0f,1f) * rotSpeed * Time.fixedDeltaTime);
    }
    public void RotRight()
    {
        player.transform.Rotate(new Vector3(0f,0f,-1f) * rotSpeed * Time.fixedDeltaTime);
    }
    
}
