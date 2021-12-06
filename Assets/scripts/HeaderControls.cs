using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeaderControls : MonoBehaviour
{

    [SerializeField] bool paused = false;
    public Text buttonText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PauseResume(){
        if (paused){
            Time.timeScale = 1.0f;
            buttonText.text = "Pause";
            
        }

        else {
            Time.timeScale = 0.0f;
            buttonText.text = "Resume";
        }

        paused = !paused;
    }


    public void Menu(){

        PersistentData.Instance.SetIndex(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("menu");

    }
}
