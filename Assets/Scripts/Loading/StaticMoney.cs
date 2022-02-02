using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMoney : MonoBehaviour
{
    //STARTING MONEY
    private static float money = 5000;

    private static float stolenMoney = 0;

    private static float refundedMoney = 0;

    private static float totalMoney = 5000;

    private static int robbersAlive = 0;

    private static int lastScene = 0;

    public static float GetMoneyCount() { return money; }
    public static float GetStolenMoney() { return stolenMoney; }
    public static float GetRefundedMoney() { return refundedMoney; }
    public static float GetTotalMoney() { return totalMoney; }
    public static float GetTotalMoneyCount() { return totalMoney; }
    public static int GetRobbersAlive() { return robbersAlive; }
    public static void AddMoney(float amount) {
        money += amount;
    }
    public static void RemoveMoney(float amount) {
        money -= amount; 
    }
    public static void SetMoney(float amount)
    {
        money = amount;
    }
    public static void SetStolenMoney(float amount)
    {
        stolenMoney = amount;
    }
    public static void SetRefundedMoney(float amount)
    {
        refundedMoney = amount;
    }
    public static void SetTotalMoney(float amount)
    {
        totalMoney = amount;
    }
    public static void ResetMoney() { money = totalMoney; }
    public static void SetRobbersAlive(int robbers) {robbersAlive = robbers;}
    public static int GetLastScene() {return lastScene;}
    public static void SetLastScene(int scene) {lastScene = scene;}
}
