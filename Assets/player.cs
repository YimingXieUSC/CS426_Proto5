using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{
    
    public List<int> moveList;

    public int currentMove;

    public int moveSize;

    public int idx;

    public bool startup;
    
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        moveList = new List<int>();

    }


    void init(){
        currentMove=moveList[0];
        moveSize= moveList.Count;
        idx=0;
        duration=1f;
    }

    void NextMove(){
        idx++;
        if (idx<moveSize)
        {
            currentMove=moveList[idx];
        }
        else{
           currentMove=-1; 
        }
        

    }

    // Update is called once per frame
    void Update()
    {
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
    }


    IEnumerator MoveDown() {
         float elapsedTime = 0f;
         while (elapsedTime < duration) {
             transform.position=(Vector2.down*Time.deltaTime*.05f);
             elapsedTime += Time.deltaTime;
             yield return null;
         }
         if (elapsedTime == duration)
         {
            NextMove(); 
         }
     }

     IEnumerator MoveUp() {
         float elapsedTime = 0f;
         while (elapsedTime < duration) {
             transform.position=(Vector2.up*Time.deltaTime*.05f);
             elapsedTime += Time.deltaTime;
             yield return null;
         }
         if (elapsedTime == duration)
         {
            NextMove(); 
         }
     }
     IEnumerator MoveRight() {
         float elapsedTime = 0f;
         while (elapsedTime < duration) {
             transform.position=(Vector2.right*Time.deltaTime*.05f);
             elapsedTime += Time.deltaTime;
             yield return null;
         }
         if (elapsedTime == duration)
         {
            NextMove(); 
         }
         
     }
     IEnumerator MoveLeft() {
         float elapsedTime = 0f;
         while (elapsedTime < duration) {
             transform.position=(Vector2.left*Time.deltaTime*.05f);
             elapsedTime += Time.deltaTime;
             yield return null;
         }
         if (elapsedTime == duration)
         {
            NextMove(); 
         }
     }
     IEnumerator pause() {
         float elapsedTime = 0f;
         while (elapsedTime < duration) {
             elapsedTime += Time.deltaTime;
             yield return null;
         }
         if (elapsedTime == duration)
         {
            NextMove(); 
         }
     }
}
