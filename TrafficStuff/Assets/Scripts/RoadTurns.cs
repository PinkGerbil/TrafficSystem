using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTurns : MonoBehaviour
{
    public bool UpPath;
    public bool RightPath;
    public bool DownPath;
    public bool LeftPath;

    public bool ReturnUpPath()
    {
        return UpPath;
    }
    public bool ReturnRightPath()
    {
        return RightPath;
    }
    public bool ReturnDownPath()
    {
        return DownPath;
    }
    public bool ReturnLeftPath()
    {
        return LeftPath;
    }
    //use for possible optimization 
    //private void Update()
    //{
    //    if(RightPath && LeftPath && !UpPath && !DownPath)
    //    {
    //        gameObject.GetComponent<SpecialActionRoad>().NormalRoad = true; 
    //    }
    //    if(!RightPath && !LeftPath && UpPath && DownPath)
    //    {
    //        gameObject.GetComponent<SpecialActionRoad>().NormalRoad = true;
    //    }
    //}
}
