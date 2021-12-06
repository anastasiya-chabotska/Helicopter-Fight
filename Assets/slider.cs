using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class slider : MonoBehaviour
{

    public Slider mySlider;
    // Start is called before the first frame update
    void Start()
    {
        mySlider.value = PersistentData.Instance.GetVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
