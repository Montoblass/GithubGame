using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour {

    private Image content; //Quelle
    
    private float currentFill;  //was angezeigt wird in der UI von 0 bis 1

    public float MyMaxValue { get; set; }

    private float currentValue;

    public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            if(value > MyMaxValue)
            {
                currentValue = MyMaxValue;
            }
            else if (value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }

            currentFill = currentFill / MyMaxValue;
        }
    }

	// Use this for initialization
	void Start () {
        MyMaxValue = 100;
        content = GetComponent<Image>();
		
	}
	
	// Update is called once per frame
	void Update () {
        content.fillAmount = currentFill;
	}
    
}
