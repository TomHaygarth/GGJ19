using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingBounce : MonoBehaviour
{

    [SerializeField]
    Animator buildAnim;
    public void bounce() {
        buildAnim.SetTrigger("bounce");
    }
}
