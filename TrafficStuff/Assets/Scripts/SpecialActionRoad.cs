using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialActionRoad : MonoBehaviour
{
    public bool UTurn;//state 1
    public bool LTurn;//state 2
    public bool TTurn;//state 3
    public bool NormalRoad;//state 4

    public int state;

    // Update is called once per frame
    void Update()
    {
        if (UTurn)
        {
            state = 1;
        }
        else if (LTurn)
        {
            state = 2;
        }
        else if (TTurn)
        {
            state = 3;
        }
        else if (NormalRoad)
        {
            state = 4; 
        }
    }
}
