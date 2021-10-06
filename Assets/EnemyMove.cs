using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update

       public List<int> moveList;

    public int currentMove;

    public int moveSize;

    public int idx;

    public bool startup;
    
    public float duration;

    public float mov=.008f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            animator.Play("EIdle");
        }
        else if(Input.GetKeyDown(KeyCode.W)){
            animator.Play("EWalk");
        }

        if(startup){
            init();
            startup=false;
        }
        else if (currentMove==0)
        {
            StartCoroutine(pause());
        }
        else if (currentMove==1)
        {
            StartCoroutine(MoveUp());
        }
        else if (currentMove==2)
        {
            StartCoroutine(MoveDown());
        }
        else if (currentMove==3)
        {
            StartCoroutine(MoveLeft());
        }
        else if (currentMove==4)
        {
            StartCoroutine(MoveRight());
        }
        else if (currentMove==5)
        {
            
        }
        else{

        }
    }

     IEnumerator MoveDown() {
         float elapsedTime = 0f;
         while (elapsedTime < duration) {
             transform.position+=(Vector3.down*Time.deltaTime*mov);
             elapsedTime += Time.deltaTime;
             yield return null;
         }
         if (elapsedTime >= duration)
         {
            NextMove();
            Debug.Log("move down");
            StopAllCoroutines();
            yield break;
            
         }
     }

     IEnumerator MoveUp() {
         float elapsedTime = 0f;
         while (elapsedTime < duration) {
             transform.position+=(Vector3.up*Time.deltaTime*mov);
             elapsedTime += Time.deltaTime;
             yield return null;
         }
         if (elapsedTime >= duration)
         {
            NextMove(); 
            Debug.Log("move up");
            StopAllCoroutines();
            yield break;
            
         }
     }
     IEnumerator MoveRight() {
         float elapsedTime = 0f;
         while (elapsedTime < duration) {
             transform.position+=(Vector3.right*Time.deltaTime*mov);
             elapsedTime += Time.deltaTime;
             yield return null;
         }
         if (elapsedTime >= duration)
         {
            NextMove(); 
            Debug.Log("move right");
            StopAllCoroutines();
            yield break;
            
         }
         
     }
     IEnumerator MoveLeft() {
         float elapsedTime = 0f;
         while (elapsedTime < duration) {
             transform.position+=(Vector3.left*Time.deltaTime*mov);
             elapsedTime += Time.deltaTime;
             yield return null;
         }
         if (elapsedTime >= duration)
         {
            NextMove(); 
            Debug.Log("move left");
            StopAllCoroutines();
            yield break;
            
         }
     }
     IEnumerator pause() {
         float elapsedTime = 0f;
         while (elapsedTime < duration) {
             elapsedTime += Time.deltaTime;
             yield return null;
         }
         if (elapsedTime >= duration)
         {
            NextMove(); 
            Debug.Log("pause");
            StopAllCoroutines();
            yield break;
            
         }
     }

     void NextMove(){
        currentMove=Random.Range(0, 5);
     }
        



    void init(){
        currentMove=0;
        
        duration=1f;
    }
    
}
