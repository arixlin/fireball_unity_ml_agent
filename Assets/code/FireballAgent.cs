using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAgent : Agent
{
    public float speed = 200;
    FireballAcademy myAcademy;
    public Rigidbody2D agentFB;
    FoodManager fm = new FoodManager();

    public override void InitializeAgent()
    {
        base.InitializeAgent();
        //agentFB = GetComponent<Rigidbody2D>();
        //myAcademy = GetComponent<FireballAcademy>();
    }

    public override void CollectObservations()
    {
        //base.CollectObservations();
        string[] detectabelObjects = { "food", "badfood", "agent" };
        AddVectorObs(agentFB.gravityScale);
        AddVectorObs(agentFB.position);
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        // System.Console.WriteLine(vectorAction);
        // base.AgentAction(vectorAction, textAction);
        int action = Mathf.FloorToInt(vectorAction[0]);
        // 0 - Up, 1 - Down, 2 - Left, 3 - Right
        if (action == 3)
        {
            agentFB.velocity = Vector2.right * 15f;
        }
        if (action == 2)
        {
            agentFB.velocity = Vector2.left * 15f;
        }
        if (action == 0)
        {
            agentFB.velocity = Vector2.up * 15f;
        }
        if (action == 1)
        {
            agentFB.velocity = Vector2.down * 15f;
        }

        EdgeProcess();
        //agentFB.AddForce();
    }

    public override void AgentReset()
    {
        base.AgentReset();
    }

    void EdgeProcess()
    {
        if (agentFB.position.x < -100)
        {
            agentFB.MovePosition(new Vector2(-100, agentFB.position.y));
            SetReward(-1f);
            //AddReward(-0.1f);
        }
        else if (agentFB.position.x > 100)
        {
            agentFB.MovePosition(new Vector2(100, agentFB.position.y));
            SetReward(-1f);
            //AddReward(-0.1f);
        }
        else if (agentFB.position.y > 100)
        {
            agentFB.MovePosition(new Vector2(agentFB.position.x, 100));
            SetReward(-1f);
            //AddReward(-0.1f);
        }
        else if (agentFB.position.y < 0)
        {
            agentFB.MovePosition(new Vector2(agentFB.position.x, 0));
            SetReward(-1f);
            //AddReward(-0.1f);
        }
        else
        {
            SetReward(0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "food")
        {
            Destroy(col.gameObject);
            SetReward(1f);
            //AddReward(1f);
            FoodManager.foodnum--;
            if (FoodManager.foodnum <= 200)
            {
                //InvokeRepeating("BuildFood", 0, 1);
                fm.BuildFood();
                FoodManager.foodnum++;
            }
        }
        if (col.transform.tag == "badfood")
        {
            Destroy(col.gameObject);
            SetReward(-1f);
            //AddReward(-1f);
            FoodManager.badfoodnum--;
            if (FoodManager.badfoodnum <= 50)
            {
                //InvokeRepeating("BuildBadFood", 0, 1);
                fm.BuildBadFood();
                FoodManager.badfoodnum++;
            }
        }
    }
    
}
