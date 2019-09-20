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
        TravelDirection(); 
        if (!isStopped)
        {
            transform.Translate(Vector3.forward / 5);
        }
    }

    private void TravelDirection()
    {
        if (transform.rotation.y == 0)
        {
            DirectionOfTravel = 1;
        }
        else if (transform.rotation.y == 90 || transform.rotation.y == -270)
        {
            DirectionOfTravel = 2;
        }
        else if (transform.rotation.y == 180 || transform.rotation.y == -180)
        {
            DirectionOfTravel = 3;
        }
        else if (transform.rotation.y == 270 || transform.rotation.y == -90)
        {
            DirectionOfTravel = 4;
        }
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
            //if the road is a u turn
            if (HitObject.collider.gameObject.GetComponent<SpecialActionRoad>().state == 1)
            {
                //u turn
                transform.Rotate(new Vector3(0, 180, 0));
                transform.Translate(-5, 0, 0);
                TraversedObject = HitObject.collider.gameObject;
            }
            //if the road is an L shaped turn
            else if(HitObject.collider.gameObject.GetComponent<SpecialActionRoad>().state == 2)
            {
                if (HitObject.collider.gameObject.GetComponent<RoadTurns>().ReturnUpPath())
                {
                    //ignore direction of travel 1 & 3
                    if (DirectionOfTravel == 2)
                    {
                        //turn left
                        transform.Rotate(new Vector3(0, -90, 0));
                        transform.Translate(5, 0, 0);
                        return;
                    }
                    else if(DirectionOfTravel == 4)
                    {
                        //turn right
                        transform.Rotate(new Vector3(0, 90, 0));
                        transform.Translate(-5, 0, 0);
                        return;
                    }
                }
                else if (HitObject.collider.gameObject.GetComponent<RoadTurns>().ReturnRightPath())
                {
                    //ignore direction of travel 2 & 4
                    if (DirectionOfTravel == 3)
                    {
                        //turn left
                        transform.Rotate(new Vector3(0, -90, 0));
                        transform.Translate(5, 0, 0);
                        return;
                    }
                    else if (DirectionOfTravel == 1)
                    {
                        //turn right
                        transform.Rotate(new Vector3(0, 90, 0));
                        transform.Translate(-5, 0, 0);
                        return;
                    }
                }
                else if (HitObject.collider.gameObject.GetComponent<RoadTurns>().ReturnDownPath())
                {
                    //ignore direction of travel 1 & 3
                    if (DirectionOfTravel == 4)
                    {
                        //turn left
                        transform.Rotate(new Vector3(0, -90, 0));
                        transform.Translate(5, 0, 0);
                        return;
                    }
                    else if (DirectionOfTravel == 2)
                    {
                        //turn right
                        transform.Rotate(new Vector3(0, 90, 0));
                        transform.Translate(-5, 0, 0);
                        return;
                    }
                }
                else if (HitObject.collider.gameObject.GetComponent<RoadTurns>().ReturnLeftPath())
                {
                    //ignore direction of travel 2 & 4
                    if (DirectionOfTravel == 1)
                    {
                        //turn left
                        transform.Rotate(new Vector3(0, -90, 0));
                        transform.Translate(5, 0, 0);
                        return;
                    }
                    else if (DirectionOfTravel == 3)
                    {
                        //turn right
                        transform.Rotate(new Vector3(0, 90, 0));
                        transform.Translate(-5, 0, 0);
                        return;
                    }
                }

                TraversedObject = HitObject.collider.gameObject;
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
            //if the road is a T shape
            //not in use as of now
            else if (HitObject.collider.gameObject.GetComponent<SpecialActionRoad>().state == 3)
            {
                //T turn
                TraversedObject = HitObject.collider.gameObject;
                transform.Rotate(new Vector3(0, -90, 0));
                transform.Translate(-5, 0, 0);
            }
            //if the road is straight with no turns
            else if (HitObject.collider.gameObject.GetComponent<SpecialActionRoad>().state == 4)
            {
                //normal road
                //TraversedObject = null; 
            }
        }
    }
}
