using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharBehavior : MonoBehaviour {

    [SerializeField]
    Animator charAnimator;

    void goLeft() {
        charAnimator.SetTrigger("goLeft");
    }

    void goRight() {
        charAnimator.SetTrigger("goRight");
    }

    void doDance() {
        charAnimator.SetTrigger("goDance");
    }

    void doJump() {
        charAnimator.SetTrigger("goUp");
    }

    void walkLeft()
    {
        charAnimator.SetTrigger("lWalk");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            doJump();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            doDance();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            goLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            goRight();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
