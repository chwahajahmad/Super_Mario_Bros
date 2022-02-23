
using UnityEngine;

public class EnemyRecord : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int damageToPlayer;
    [SerializeField] int killRewardForPlayer;

    bool isDead;

    public void decHealth(int h = 1)
    {
        health-=1;
        if(health <= 0)
            isDead = true;
    }

    public bool getIsDead()
    {
        return isDead;
    }
    public void setIsDead(bool t = true)
    {
        isDead = t;
    }


    public int getDamage()
    {
        return damageToPlayer;
    }

    public int getRewardForPlayer()
    {
        return killRewardForPlayer;
    }

}
