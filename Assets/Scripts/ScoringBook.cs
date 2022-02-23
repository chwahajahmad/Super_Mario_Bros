
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoringBook : MonoBehaviour
{
    // Start is called before the first frame update

    static int score = ScoringScr.score;
    static int health = ScoringScr.health;
    static int coins = ScoringScr.health;
    static int power = ScoringScr.power;
    static int level = ScoringScr.level;

    public Text scoreT;
    public Text levelT;
    public Text coinsT;
    public Text healthT;
  
    // Update is called once per frame
    private void Start()
    {
        int score = ScoringScr.score;
        int health = ScoringScr.health;
        int coins = ScoringScr.health;
        int power = ScoringScr.power;
        int level = ScoringScr.level;

    }
    void FixedUpdate()
    {
        scoreT.text = "" + score;
        levelT.text = "Level\n" + level;
        coinsT.text = "Coins\n" + coins;
        healthT.text = "Lives\n" + health;
    }

    public void updateScore(int n)
    {
        if (n >= 0)
            score += n;
    }
    public int getScore()
    {
        return score;
    }

    public void decreaseHealth(int damage)
    {
        if (power - damage <= 0)
        {
            
            health--;
            if (health <= 0)
            {
                restart();
            }
            death();
            GameObject.Find("Player").GetComponent<PlayerMovement>().playerDeath();
            
        }
        else
            setPower(-damage);
    }
    public int getHealth()
    {
        return health;
    }

    public int getPower()
    {
        return power;
    }

    public void setPower(int n = 1)
    {
        if(power+n<=3 && power+n>=1)
        {
            power+=n;
            GameObject.Find("Player").GetComponent<PowerChange>().changePower(power);
        }
    }

    public int getLevel()
    {
        return level;
    }

    public void increaseLevel()
    {
        level+=1;
    }

    public void resetScore()
    {
        score = 0;
    }
    public void resetCoins()
    {
        coins = 0;
    }
    public void resetHealth()
    {
        health = 3;
    }
    public void resetLevel()
    {
        level = 1;
    }
    public void resetPower()
    {
        power = 1;
    }


    public void death()
    {
        resetScore();
        resetCoins();
        resetPower();
        resetLevel();
    }

    public void restart()
    {
        death();
        resetHealth();
    }
    
   
}
