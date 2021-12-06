using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ai_movement : MonoBehaviour
{

[SerializeField] Rigidbody2D rigid;
    public float speed = 20f;
    public float stoppingDistance =20f;
    public bool isFacingRight = false;
    public bool targetIsFacingRight;
    public float movement;
    public GameObject bullet;
    private Transform target;

    void Start(){
        if (rigid == null){
    rigid = GetComponent<Rigidbody2D>();
}
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
       InvokeRepeating("FireBullet", 2.0f, 0.7f);

        
    }
    void Update(){

        movement = GameObject.FindGameObjectWithTag("player").GetComponent<plane>().movement;


        

        // if ((movement < 0 && isFacingRight) || (movement > 0 && !isFacingRight)){
        //       transform.Rotate(0, 180, 0);
        // isFacingRight = !isFacingRight;
        // }

        if (transform.position.x > target.position.x && isFacingRight){
            Flip();
        }

        else if (transform.position.x < target.position.x && !isFacingRight){
            Flip();
        }

        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        // transform.rotation = target.rotation;
        if (Vector2.Distance(transform.position, target.position)>stoppingDistance){
           
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

       private void FireBullet(){
       
GameObject myBullet = (GameObject) Instantiate(bullet, new Vector3(rigid.position.x, rigid.position.y, 0), Quaternion.identity);
myBullet.gameObject.tag = "enemy_bullet";
if (isFacingRight == false){
myBullet.GetComponent<bullet>().moveRight = false;
}
else myBullet.GetComponent<bullet>().moveRight = true;
 
      
    }

    private void Flip(){
          transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
      
        Debug.Log("Flipped");
    }

}