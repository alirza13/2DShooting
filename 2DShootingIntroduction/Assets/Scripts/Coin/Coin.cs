using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int pointValue = 10;
    private PlayerMovement player;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered collision");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision Occurred");
            collision.gameObject.GetComponent<PlayerMovement>().AddPoints(pointValue);
            gameObject.SetActive(false);
        }
    } 
}
