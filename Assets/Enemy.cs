using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public player robotplayer;
    [SerializeField] public Vector2 OriginPosition;
    int statusCode = 0;
    private float latestDirectionChangeTime;
    public readonly float directionChangeTime = 2f;
    private float characterVelocity = 2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    Animator animator;

    void calcuateNewMovementVector(){
        Vector2 randomXDirection = new Vector2(Random.Range(-1.0f, 1.0f), 0).normalized;
        Vector2 randomYDirection = new Vector2(0, Random.Range(-1.0f, 1.0f)).normalized;
        int number = Random.Range(1,4);
        if(number < 3){
             //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
            movementDirection = randomXDirection;
        }
        else{
            movementDirection = randomYDirection;
        }
        movementPerSecond = movementDirection * characterVelocity;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("EWalk");
        OriginPosition = transform.position;
        Debug.Log("Origin position: "+ OriginPosition.x + " " + OriginPosition.y);
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
    }

    bool detectPlayer(){
        //Debug.Log("Player position: " + robotplayer.transform.position.x + ": " + robotplayer.transform.position.y);
        float distance = Mathf.Pow(Mathf.Pow(robotplayer.transform.position.x - transform.position.x, 2)+ Mathf.Pow(robotplayer.transform.position.y - transform.position.y, 2), 0.5f);
        Debug.Log("Ditance: " + distance);
        if(distance < 2){
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime){
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }
        //move enemy: 
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y + (movementPerSecond.y * Time.deltaTime));
        bool playerComing = detectPlayer();
        if(playerComing){
            animator.Play("EAttack");
        }
        else{
            animator.Play("EWalk");
        }
}
}
