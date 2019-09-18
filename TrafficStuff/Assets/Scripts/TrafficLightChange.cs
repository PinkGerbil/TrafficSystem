using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightChange : MonoBehaviour
{
    Material Light_Red;
    Material Light_Blue;
    Material Light_Green;

    float RedTimer;
    float YellowTimer;
    float GreenTimer;

    float RedTimerLimit;
    float YellowTimerLimit;
    float GreenTimerLimit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RedTimer += Time.deltaTime;
        YellowTimer += Time.deltaTime;
        GreenTimer += Time.deltaTime;


    }

    private void LightChangeToRed()
    {

    }

    private void LightChangeToYellow()
    {

    }

    private void LightChangeToGreen()
    {

    }
}
