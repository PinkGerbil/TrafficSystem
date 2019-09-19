using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightChange : MonoBehaviour
{
    public Material Light_Red;
    public Material Light_Yellow;
    public Material Light_Green;

    public float RedTimer;
    public float YellowTimer;
    public float GreenTimer;

    public float RedTimerLimit;
    public float YellowTimerLimit;
    public float GreenTimerLimit;

    public bool RedLightActive = true;
    public bool YellowLightActive = false;
    public bool GreenLightActive = false;

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

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    LightChangeToRed();
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    LightChangeToYellow();
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    LightChangeToGreen();
        //}


        if(GreenTimer > GreenTimerLimit && GreenLightActive)
        {
            GreenLightActive = false;
            LightChangeToYellow();
        }
        if(YellowTimer > YellowTimerLimit && YellowLightActive)
        {
            YellowLightActive = false; 
            LightChangeToRed();
        }
        if(RedTimer > RedTimerLimit && RedLightActive)
        {
            RedLightActive = false;
            LightChangeToGreen();
        }
    }

    private void LightChangeToRed()
    {
        RedLightActive = true;
        ResetTimers();
        this.gameObject.GetComponent<MeshRenderer>().material = Light_Red;
    }

    private void LightChangeToYellow()
    {
        YellowLightActive = true;
        ResetTimers();
        this.gameObject.GetComponent<MeshRenderer>().material = Light_Yellow;
    }

    private void LightChangeToGreen()
    {
        GreenLightActive = true;
        ResetTimers();
        this.gameObject.GetComponent<MeshRenderer>().material = Light_Green;
    }

    private void ResetTimers()
    {
        RedTimer = 0;
        YellowTimer = 0;
        GreenTimer = 0; 
    }
}
