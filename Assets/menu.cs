using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{

     [SerializeField] InputField input;
     [SerializeField] Text playButtonText;
     [SerializeField] int index;
     public Text finalScoreText;


    // Start is called before the first frame update
    void Start()
    {
        index = PersistentData.Instance.GetIndex();
        string pName = PersistentData.Instance.GetName();

        if(SceneManager.GetActiveScene().name=="menu"){
        if (pName != "")
            input.placeholder.GetComponent<Text>().text = pName;
        if (index > 0)
           playButtonText.text = "RESUME";
           
           

        }

        // if (index == 0){
        //     if(PersistentData.Instance.GetMode()){
        //        playButtonText.text = "PLAY AGAIN";

        //    }
        // }

           if (SceneManager.GetActiveScene().name=="end"){
               finalScoreText.text = "YOU WON!\nYOUR SCORE: "+PersistentData.Instance.GetScore();
           }
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame(){


 if (index > 0)
        {
            SceneManager.LoadScene(index);
            Time.timeScale = 1;
        }
        else
        {
            if(PersistentData.Instance.GetName()==""){
            string playerName = input.text;
            PersistentData.Instance.SetName(playerName);
            }
            SceneManager.LoadScene("level1");
        }
        


        


    }

    public void Settings(){
        SceneManager.LoadScene("settings");
    }

    public void Menu(){
        if (SceneManager.GetActiveScene().name=="end"){
            PersistentData.Instance.SetScore(0);
            PersistentData.Instance.SetIndex(0);
            PersistentData.Instance.SetMode();
            
        }
        SceneManager.LoadScene("menu");
    }

    public void Instructions(){
        SceneManager.LoadScene("instructions");
    }


    public void HighScores(){
        SceneManager.LoadScene("highScores");
    }



    public void ChangeVolume(System.Single sliderValue){

        Debug.Log("VALUE CHANGED: "+ sliderValue);
        PersistentData.Instance.SetVolume(sliderValue); 
    }
}
