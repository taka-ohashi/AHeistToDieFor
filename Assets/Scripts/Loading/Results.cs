using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Results : MonoBehaviour
{

    public GameObject button;
    public float money = 100;
    public int robbersAlive = 4;

    private float countingMoney = 0;
    private int countingRobbers = 0;
    private float addingAmount = 0.5f;
    private float speedup = 0;
    private float speedupAmount = 0.1f;

    private float total = 0;
    private float stolenMoney = 0;
    private float refundedMoney = 0;

    private bool doneCountingMoney = false;
    private bool doneCountingRobbers = false;
    private bool doneCountingTotal = true;
    private bool robberWaiting = false;

    private string moneyText;

    private bool resetTotal = false;

    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();

        robbersAlive = StaticMoney.GetRobbersAlive();

        money = StaticMoney.GetMoneyCount();

        stolenMoney = StaticMoney.GetStolenMoney();

        refundedMoney = StaticMoney.GetRefundedMoney();

        total = StaticMoney.GetTotalMoneyCount();
    }

    // Update is called once per frame
    void Update()
    {
        if(!doneCountingMoney)
        {
            CountMoney();
        }
        else if(!doneCountingRobbers)
        {
            CountRobbers();
        }
        else if(!doneCountingTotal)
        {
            if(!resetTotal) {addingAmount = 0; resetTotal = true;}
            CountTotal();
        }
    }

    private void CountMoney()
    {
        //this method counts up the money
        countingMoney += (int) (addingAmount + speedup);

        if(countingMoney > stolenMoney)
        {
            speedup = 0;

            doneCountingMoney = true;

            countingMoney = (int) stolenMoney;

            text.text = "" + countingMoney;

            //stores text values for money collected
            moneyText = text.text + "\n\n";
        }

        text.text = "" + countingMoney;

        speedup += speedupAmount;
    }

    private void CountRobbers()
    {
        //this method couts up the robbers
        if(countingRobbers < robbersAlive)
        {
            if(!robberWaiting)
            {
                StartCoroutine("LoadRobbers");
            }
        }
        else
        {
            doneCountingRobbers = true;

            //resets for counting total
            countingMoney = 0;

            //stores text values for robbers alive
            moneyText = text.text + "\n\n";

            //stores total money the player earned
            total = money + stolenMoney + refundedMoney;

            StartCoroutine("WaitTotal");
        }
    }

    private void CountTotal()
    {
        countingMoney += (int) (addingAmount + speedup);

        if(countingMoney > total)
        {
            doneCountingMoney = true;

            countingMoney = (int) total;

            doneCountingTotal = true;

            // sets money to total money to prepare for next map
            StaticMoney.SetMoney(StaticMoney.GetTotalMoney());

            button.SetActive(true);
        }

        text.text = moneyText + countingMoney;

        speedup += speedupAmount;
    }



    IEnumerator LoadRobbers()
    {
        robberWaiting = true;
        yield return new WaitForSeconds(.5f);
        countingRobbers += 1;
        text.text = moneyText + countingRobbers;
        robberWaiting = false;
    }

    IEnumerator WaitTotal()
    {
        yield return new WaitForSeconds(.5f);
        doneCountingTotal = false;
    }


}
