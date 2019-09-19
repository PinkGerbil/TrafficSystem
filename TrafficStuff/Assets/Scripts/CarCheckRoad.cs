using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCheckRoad : MonoBehaviour
{
    public bool isStopped;

    public GameObject TraversedObject;

    public int DirectionOfTravel; 
    //1 = up
    //2 = right
    //3 = down
    //4 = right

    // Update is called once per frame
    void Update()
    {
        RaycastDetect();

        if (!isStopped)
        {
            transform.Translate(Vector3.forward / 5);
        }
    }

    private void TravelDirection()
    {

    }
    private void RaycastDetect()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
        {
            if(hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponentInChildren<TrafficLightChange>() != null)
                {
                    CheckLights(hit);
                }
                else if(hit.collider.gameObject.GetComponent<SpecialActionRoad>() != null)
                {
                    CheckSpecialRoad(hit);
                }
            }
        }
    }
    private void CheckLights(RaycastHit HitObject)
    {
        if (HitObject.collider.gameObject.GetComponentInChildren<TrafficLightChange>().state == 1)
        {
            //red light
            //stop
            isStopped = true;
        }
        else if (HitObject.collider.gameObject.GetComponentInChildren<TrafficLightChange>().state == 2)
        {
            //yellow light
            //slow to stop
            isStopped = true;
        }
        else if (HitObject.collider.gameObject.GetComponentInChildren<TrafficLightChange>().state == 3)
        {
            //green light
            //keep going or start going if stopped
            if (isStopped == true)
            {
                isStopped = false;
            }
        }
    }
    private void CheckSpecialRoad(RaycastHit HitObject)
    {
        if(HitObject.collider.gameObject != TraversedObject)
        {
            if (HitObject.collider.gameObject.GetComponent<SpecialActionRoad>().state == 1)
            {
                //u turn
                transform.Rotate(new Vector3(0, 180, 0));
                transform.Translate(-5, 0, 0);
            }
            else if(HitObject.collider.gameObject.GetComponent<SpecialActionRoad>().state == 2)
            {
                //L shaped turn
                //
                //    turn left
                //    transform.Rotate(new Vector3(0, -90, 0));
                //    transform.Translate(5, 0, 0);
                //    return;
                //
                //
                //    turn right
                //    transform.Rotate(new Vector3(0, 90, 0));
                //    transform.Translate(-5, 0, 0);
                //    return;
                //

            }
            else if (HitObject.collider.gameObject.GetComponent<SpecialActionRoad>().state == 3)
            {
                //T turn
                transform.Rotate(new Vector3(0, -90, 0));
                transform.Translate(-5, 0, 0);
            }
            TraversedObject = HitObject.collider.gameObject;
        }
    }
}
