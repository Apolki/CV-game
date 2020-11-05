using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXP : MonoBehaviour
{
    public float level;
    public Image BarExp;
    public float fillExp;
    public Image BarHP;
    public static float fillHP;
    private float expRequired = 0f;
    public static float exp = 0f;
    public static float hp = 100f;
    public static float fullhp = 100f;


    private void Start()
    {
        fillHP = 1f;
        fillExp = 0f;
        level = 1f;
        expRequired = 10;
    }
        

    private void Update()
    {
        BarHP.fillAmount = hp/fullhp;

        fillExp = exp / expRequired;
        BarExp.fillAmount = fillExp;
        Exp();
        

    }

    void LevelUpSpeed()
    {
        level += 1;
        Movee_Hero.movementSpeed += 2;
        exp -= expRequired;
        expRequired += level * 10;
        
    }

    void Exp()
    {
        if (exp >= expRequired)
            if(Input.GetKeyDown(KeyCode.Alpha1))
                LevelUpSpeed();
        if (exp >= expRequired)
            if (Input.GetKeyDown(KeyCode.Alpha2))
                levelUpJump();
        if (exp >= expRequired)
            if (Input.GetKeyDown(KeyCode.Alpha3))
                levelUpHP();
    }

    private void levelUpHP()
    {
        level += 1;
        hp += 50;
        fullhp += 50;
        exp -= expRequired;
        expRequired += level * 10;
    }

    private void levelUpJump()
    {
        level += 1;
        Movee_Hero.jumpForce += 2;
        exp -= expRequired;
        expRequired += level * 10;
        
           
    }
}
