using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane : MonoBehaviour
{


[SerializeField] GameObject bullet;


     [SerializeField] float speed = 50f;
    //horizontal
   public float movement;
    //vertical
    [SerializeField] float movement_1;
    [SerializeField] Rigidbody2D rigid;

    public bool isFacingRight = true;

    [SerializeField] bool fireBullet = false;
    [SerializeField] Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {

     if (rigid==null)
        rigid = GetComponent<Rigidbody2D>();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
      

    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        movement_1 = Input.GetAxis("Vertical");

         if (Input.GetButtonDown("Fire1"))
           
            FireBullet();

            clampPlayerMovement();
    }

    private void FixedUpdate(){
    
        rigid.velocity= new Vector2(movement * speed, movement_1 * speed);

      
      
        if(movement < 0 && isFacingRight || movement > 0 && !isFacingRight){
            Flip();
        }


       

    }

     void clampPlayerMovement()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    private void Flip(){
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }


    private void FireBullet(){
        
GameObject myBullet = (GameObject) Instantiate(bullet, new Vector3(rigid.position.x, rigid.position.y, 0), Quaternion.identity);
myBullet.gameObject.tag="player_bullet";
if (isFacingRight == false){
myBullet.GetComponent<bullet>().moveRight = false;
}
else myBullet.GetComponent<bullet>().moveRight = true;
 fireBullet = false;
        
    }
}
