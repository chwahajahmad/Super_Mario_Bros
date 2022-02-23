
using UnityEngine;

public class CollisionOperations : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject breakTile;
    [SerializeField] int minPowerToBreak = 1;
    [SerializeField] int reward = 50;
    [SerializeField] bool breakAble = false;
    GameObject scoring;

    private void Start()
    {
        scoring = GameObject.Find("Scoring");        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(scoring.GetComponent<ScoringBook>().getPower() >= minPowerToBreak && breakAble && other.gameObject.tag == "Player")
        {
            scoring.GetComponent<ScoringBook>().updateScore(reward);
            BreakTile(transform.position);
            Destroy(this.gameObject,0.02f);
        }
       
    }
    void BreakTile(Vector2 position) {
        GameObject.Find("VFXSoundManager").GetComponent<VFXSOUNDMANAGER>().PlaySound("tileBreak");
		const float gravity = -0.01f;
		const float hor = 0.01f;
		Instantiate(breakTile, position, Quaternion.identity).GetComponent<TileBreak>().SetData(new Vector2(0, gravity),
			new Vector2(-hor, 0.3f));
		Instantiate(breakTile, position, Quaternion.identity).GetComponent<TileBreak>().SetData(new Vector2(0, gravity),
			new Vector2(-hor, 0.2f));
		Instantiate(breakTile, position, Quaternion.identity).GetComponent<TileBreak>().SetData(new Vector2(0, gravity),
			new Vector2(hor, 0.3f));
		Instantiate(breakTile, position, Quaternion.identity).GetComponent<TileBreak>().SetData(new Vector2(0, gravity),
			new Vector2(hor, 0.2f));
	}	
}
