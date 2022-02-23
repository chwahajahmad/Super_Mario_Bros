using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinished : MonoBehaviour 
{

	private bool reachedEnd;
    private Animator playerAnim;
    private bool executedPoleCode;
    private GameObject player;
    private bool startFlagMovement;
    private bool flagMoved;
    private bool movePlayerTowardsGoal;
    private bool scoreIncreased = true;
    private int initialScore;
    private void Start()
    {
        initialScore =  GameObject.Find("Scoring").GetComponent<ScoringBook>().getScore();
        startFlagMovement = false;
        player = GameObject.Find("Player");
        executedPoleCode = false;
        playerAnim = player.GetComponent<Animator>();
        flagMoved = false;
        movePlayerTowardsGoal = false;
    }
	void Update()
    {
        if(!executedPoleCode)
        {
            reachedEnd = player.GetComponent<PlayerCollision>().getReachedEnd();
            if(reachedEnd)
            {
                executedPoleCode = true;
                playerAnim.SetBool("levelEnd",true);
                startFlagMovement = true;
            }
        }
    }
    void FixedUpdate()
    {
        if(startFlagMovement)
        {
            if(transform.position.y > -1.4)
            {
                float y = transform.position.y-0.04f;
                transform.position = new Vector3(transform.position.x,y,0);
            }
            else
                {
                    startFlagMovement = false;
                    flagMoved = true;
                }
        }
        else if(flagMoved)
        {
            playerAnim.SetBool("levelEnd",false);
            player.transform.position = new Vector3(player.transform.position.x+1,player.transform.position.y,0);
            playerAnim.SetBool("Walk",false);
            player.GetComponent<SpriteRenderer>().flipX = true;
            flagMoved = false;
            StartCoroutine("waitTimer");
         }
        else if(movePlayerTowardsGoal)
        {
            if(player.transform.position.x<192)
            {
               playerAnim.SetBool("Walk",true);
               player.transform.position = new Vector3(player.transform.position.x+0.02f,player.transform.position.y,0);   
            }
            else
            {
                
               ;
                
                movePlayerTowardsGoal = false;
                playerAnim.SetBool("Walk",false);
                player.GetComponent<SpriteRenderer>().enabled = false;
                scoreIncreased = false;
            }
        }
        if(!scoreIncreased)
        {
            int scoreCounter = 50;
            int score = GameObject.Find("Scoring").GetComponent<ScoringBook>().getScore();
            int level = GameObject.Find("Scoring").GetComponent<ScoringBook>().getLevel();
            if(score<initialScore+10000+level*1000)
                GameObject.Find("Scoring").GetComponent<ScoringBook>().updateScore(scoreCounter);
            else
                scoreIncreased = true;
        }
    }
    
    IEnumerator waitTimer()
    {
        
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<SpriteRenderer>().flipX = false;
        player.transform.position = new Vector3(player.transform.position.x+1,player.transform.position.y,0);
        movePlayerTowardsGoal = true;
      
    }
}

