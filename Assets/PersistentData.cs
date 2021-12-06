using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentData : MonoBehaviour
{


    [SerializeField] int playerScore;
    [SerializeField] string playerName;
    [SerializeField] int currentLevelIndex;
    [SerializeField] Slider slider;
    [SerializeField] float volume;
    [SerializeField] bool playAgain = false;


      public static PersistentData Instance; 
    // Start is called before the first frame update
    void Start()
    {
        
          playerName = "";
        playerScore = 0;
        currentLevelIndex = 0;
        volume = 0.5f;
    }

 private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


      public void SetName(string n)
    {
        playerName = n;
    }

     public string GetName()
    {
        return playerName;
    }

     public void SetScore(int s)
    {
        playerScore = s;
    }


       public int GetScore()
    {
        return playerScore;
    }

      public void SetIndex(int i)
    {
        currentLevelIndex = i;
    }

    public int GetIndex()
    {
        return currentLevelIndex;
    }

    // void OnEnable()
    // {
    //     //Register Slider Events
    //     slider.onValueChanged.AddListener(delegate { changeVolume(slider.value); });
    // }

    //Called when Slider is moved
    void changeVolume(float sliderValue)
    {
        volume = sliderValue;
    }

    // void OnDisable()
    // {
    //     //Un-Register Slider Events
    //     slider.onValueChanged.RemoveAllListeners();
    // }


    public float GetVolume(){
      return volume;
    }

    public void SetVolume(float value){
    
      volume = value;

      Debug.Log("VOLUME SET "+ volume);
    }
    public void SetMode(){
    playAgain = true;
}

    public bool GetMode(){
      return playAgain;
    }
}
