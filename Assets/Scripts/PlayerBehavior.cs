using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour
{

    public Transform mesh;
    public float forceFly;
    private Animator animatorPlayer;

    private float timeToAnime;
    private bool inAnin;
	private GameControler gameControler;
  
    void Start()
    {
        animatorPlayer = mesh.GetComponent<Animator>();
		gameControler = FindObjectOfType(typeof(GameControler))as GameControler;       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameControler.getCurentState() == GameStates.INGAME)
        {
            animatorPlayer.SetBool("CallFly", true);
            inAnin = true;
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(new Vector2(0, 1) * forceFly);
		}
		else if(Input.GetMouseButtonDown(0))
		{ 
			gameControler.StartGame();
		}
		if(gameControler.getCurentState()!= GameStates.INGAME && 
		   gameControler.getCurentState() != GameStates.GAMEOVER)
		{
			rigidbody2D.gravityScale=0;
			return;
		}else{
			rigidbody2D.gravityScale=1;
		}
        
        if (inAnin)
        {
            timeToAnime += Time.deltaTime;
            if (timeToAnime > 0.4f)
            {
                timeToAnime = 0;
                inAnin = false;
            }
        }
        animatorPlayer.SetBool("CallFly", inAnin);
    }

	void OnCollisionEnter2D(Collision2D coll) {
		gameControler.GameOver();		
	}

}
