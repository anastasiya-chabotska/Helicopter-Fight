using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bullet : MonoBehaviour
{

    public GameObject controller;
     public bool moveRight = true;
    [SerializeField] Rigidbody2D rigid;
     [SerializeField] float speed = 40f;
    [SerializeField] float movement;
    [SerializeField] Vector2 screenBounds;
    [SerializeField] bool isFacingRight = true;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {



if (rigid == null){
    rigid = GetComponent<Rigidbody2D>();
        
    }

     if (audio == null)
            audio = GetComponent<AudioSource>();

  if (gameObject.tag == "enemy_bullet")
  {
    if (SceneManager.GetActiveScene().name=="level2.1"){
      speed = 70f;
    }
    else if (SceneManager.GetActiveScene().name=="level3.1"){
      speed = 100f;

    }


    //audio.volume = PersistentData.Instance.GetVolume();
  }



    controller = GameObject.FindWithTag("controller");

    screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

      if(moveRight == false && isFacingRight==true){
            Flip();

            speed = speed * -1;

    }
    }

    // Update is called once per frame
    void Update()
    {

  
      if (transform.position.x < -screenBounds[0] || transform.position.x >screenBounds[0] ){
        Destroy(rigid.gameObject);
      }
    }

    private void FixedUpdate(){


    rigid.velocity= new Vector2(speed, 0);

  
    
    }

      private void Flip(){
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }


     private void OnTriggerEnter2D(Collider2D collision)
    {

      //gameObject.GetComponent<AudioSource>().volume = PersistentData.Instance.GetVolume();
      
      if (collision.gameObject.tag=="enemy" && gameObject.tag=="player_bullet"){
      Debug.Log("collision with enemy");
 
      Destroy(rigid.gameObject);
      AudioSource.PlayClipAtPoint(audio.clip, transform.position);
       controller.GetComponent<ScoreKeeper>().SubtractEnemyPoints();
      }

      else if (collision.gameObject.tag=="player" && gameObject.tag=="enemy_bullet"){
         Debug.Log("hit by the enemy");
         
         Destroy(rigid.gameObject);
              AudioSource.PlayClipAtPoint(audio.clip, transform.position);
       controller.GetComponent<ScoreKeeper>().SubtractPlayerPoints();
      
      }
   

    //     //don't do it this way -- clumsy though it works
    //    /* audio.Play();
    //     GetComponent<SpriteRenderer>().enabled = false;
    //     GetComponent<BoxCollider2D>().enabled = false;
    //     Destroy(gameObject, 1); //destroys game object with a delay of 1 sec*/


    //     AudioSource.PlayClipAtPoint(audio.clip, transform.position);
    //     Destroy(gameObject); //destroys itself after points have been added 
    }


   
}
