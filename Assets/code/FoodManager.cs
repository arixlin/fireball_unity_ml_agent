using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour {

    public GameObject food;
    public GameObject badfood;

    public static int foodnum = 0;
    public static int badfoodnum = 0;

    public int Xmin = -99;
    public int Xmax = 99;
    public int Ymin = 1;
    public int Ymax = 99;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (foodnum <= 200)
        {
            BuildFood();
            foodnum++;
        }
        if (badfoodnum <= 50)
        {
            BuildBadFood();
            badfoodnum++;
        }
    }

    public void BuildFood() {
        float x = Random.Range(Xmin, Xmax);
        float y = Random.Range(Ymin, Ymax);

        Instantiate(food, new Vector3(x, y, 0), Quaternion.identity);
    }

    public void BuildBadFood() {
        float x = Random.Range(Xmin, Xmax);
        float y = Random.Range(Ymin, Ymax);

        Instantiate(badfood, new Vector3(x, y, 0), Quaternion.identity);
    }

    //void OnGUI()
    //{
    //    //GUI.Label(new Rect(Screen.width / 2, 20, 200, 20), "weights:" + body);
    //    GUI.Label(new Rect(Screen.width / 2, 40, 200, 20), "foodnum:" + foodnum);
    //    GUI.Label(new Rect(Screen.width / 2, 60, 200, 20), "badfoodnum:" + badfoodnum);
    //}
}
