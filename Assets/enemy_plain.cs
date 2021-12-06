using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_plain : MonoBehaviour
{

    [SerializeField] GameObject bullet;
     [SerializeField] Rigidbody2D rigid;
     [SerializeField] float movement;
     [SerializeField] bool isFacingRight = false;
     [SerializeField] bool moveRight = false;
     [SerializeField] Vector2 screenBounds;
     [SerializeField] float speed = 20f;

     
  
    //  [SerializeField] float speed = 0.1f;
    //  [SerializeField] Transform wallCheck;
    //  [SerializeField] float wallCheckRadius;
    //  [SerializeField] LayerMask whatIsWall;
    //  [SerializeField] bool hittingWall;
    
    // Start is called before the first frame update
    void Start()
    {


if (SceneManager.GetActiveScene().name=="level2.1"){
    speed = 40f;
    InvokeRepeating("FireBullet", 2.0f, 0.3f);
}

else InvokeRepeating("FireBullet", 2.0f, 0.5f);

if (rigid == null){
    rigid = GetComponent<Rigidbody2D>();
}

screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
   
        
    }

    // Update is called once per frame
    void Update()
    {

        // Vector3 viewPos = transform.position;
        // viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x, screenBounds.x*-1);
        // viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y, screenBounds.y*-1);
        // transform.position = viewPos;

        movement = rigid.velocity.x;
   
//    hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
       

 
    }

    private void FixedUpdate(){
    


            if (transform.position.x < -screenBounds[0] && moveRight == false)
        {
            moveRight = true;
          rigid.velocity= new Vector2(-(rigid.velocity.x), rigid.velocity.y);
            
            
            Flip();
        } 
        

           if (transform.position.x >= screenBounds[0] && moveRight == true)
        {
            moveRight = false;
            rigid.velocity= new Vector2(-(rigid.velocity.x), rigid.velocity.y);
           
            Flip();
        } 
        
       
            
    if (moveRight == false)
    rigid.velocity= new Vector2(-speed, rigid.velocity.y);
    else if (moveRight == true) {
    rigid.velocity = new Vector2(speed, rigid.velocity.y);
    }
        

       

         
    }

     private void Flip(){
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
      
        Debug.Log("Flipped");
    }


       private void FireBullet(){
       
GameObject myBullet = (GameObject) Instantiate(bullet, new Vector3(rigid.position.x, rigid.position.y, 0), Quaternion.identity);
myBullet.gameObject.tag = "enemy_bullet";
if (isFacingRight == false){
myBullet.GetComponent<bullet>().moveRight = false;
}
else myBullet.GetComponent<bullet>().moveRight = true;
 
      
    }


}
