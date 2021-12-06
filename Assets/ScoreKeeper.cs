using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{

    private int player_score;
    private int enemy_score;
    public int level;
    private const int DEFAULT_POINTS = 2;
    public const int START_SCORE = 50;
    public Text playerScoreTxt;
    public Text enemyScoreTxt;
    public Text levelText;
    public Text totalScoreTxt;
    [SerializeField] int total_score;
    public Animator enemy_anim;
    public Animator player_anim;



    // Start is called before the first frame update
    void Start()
    {

       total_score = PersistentData.Instance.GetScore();
        player_score = START_SCORE;
        enemy_score = START_SCORE;
        level = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(player_score);
        levelText.text = "Level: " + level;
        totalScoreTxt.text = "Score: "+total_score;
        DisplayEnemyScore();
        DisplayPlayerScore();
        PersistentData.Instance.SetIndex(level);


        AudioListener.volume = PersistentData.Instance.GetVolume();




        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void DisplayPlayerScore()
    {
        int test = player_score;
        Debug.Log("test " + test);
        playerScoreTxt.text = "Your Health: " + player_score;
    }


     public void DisplayEnemyScore()
    {
        int test = player_score;
        Debug.Log("test " + test);

        enemyScoreTxt.text = "Enemy Health: " + enemy_score;
    }



    public void SubtractPlayerPoints()
    {

        player_score -= DEFAULT_POINTS;
      
        Debug.Log("player score: "+player_score);
        DisplayPlayerScore();

          if (player_score<=25){
             player_anim.SetBool("explode", true);
        }
          if (player_score <=0){
            SceneManager.LoadScene(level);
        }
    }

     public void SubtractEnemyPoints()
    {
        enemy_score = enemy_score - DEFAULT_POINTS;
        Debug.Log("enemy score: "+enemy_score);
        DisplayEnemyScore();

        if (enemy_score<=25){
             enemy_anim.SetBool("explode", true);
        }

        if (enemy_score <=0){
           
            Debug.Log("Your score for this level: ");
            PersistentData.Instance.SetScore(PersistentData.Instance.GetScore()+(player_score-enemy_score));
     
            SceneManager.LoadScene(level+1);
        }
        // Debug.Log(enemyScoreTxt);
    }
}
