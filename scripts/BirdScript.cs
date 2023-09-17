using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public float birdSpeed;
    public LogicScript logic;
    public bool birdAlive = true;
    public float tiltUpStrength = 5f;
    public float gravity = -9.81f;
    public float tiltDownStrength = 5f;
    public AudioSource dead;
    private Vector3 direction;
    
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdAlive == true) 
        {
            myRigidbody.velocity=Vector2.up * flapStrength;
            direction = Vector3.up * tiltUpStrength;
        }
        if (Input.GetMouseButtonDown(0) == true && birdAlive == true) 
        {
            
            myRigidbody.velocity=Vector2.up * flapStrength;
            direction = Vector3.up * tiltUpStrength;
         }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tiltDownStrength;
        transform.eulerAngles = rotation;
        
        if(transform.position.y > 17){
            logic.gameOver();
            birdAlive = false;
            dead.Play();
        }
        if(transform.position.y < -17){ 
            logic.gameOver();
            birdAlive = false;
            dead.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        logic.gameOver();
        birdAlive = false;
        dead.Play();
    }

} 
