using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMenus : MonoBehaviour
{
    public float moveAmount;
    public Transform mover;
    public Transform origin;
    string menu;

    void Start()
    {
        mover.position = new Vector3(transform.position.x - moveAmount, transform.position.y);
        menu = "MainMenu";
    }
    void Update()
    {
        if (menu == "MainMenu")
        {
            transform.position = Vector3.Lerp(transform.position,  origin.position, Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position,  mover.position, Time.deltaTime);
        }
    }
    public void MoveMenusMethod(string menuName)
    {
        menu = menuName;      
    }

    
}
