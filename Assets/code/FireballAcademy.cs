using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAcademy : Academy {

    [HideInInspector]
    public GameObject[] agents;

    public override void AcademyReset()
    {
        base.AcademyReset();
        //ClearObjects(GameObject.FindGameObjectsWithTag("food"));
        //ClearObjects(GameObject.FindGameObjectsWithTag("badfood"));

        //agents = GameObject.FindGameObjectsWithTag("agent");
    }

    void ClearObjects(GameObject[] objects)
    {
        foreach (GameObject food in objects)
        {
            Destroy(food);
        }
    }
}
