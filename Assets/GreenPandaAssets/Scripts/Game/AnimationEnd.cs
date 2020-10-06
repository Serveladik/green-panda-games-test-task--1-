using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnd : MonoBehaviour
{
  public Animator animator;

  public void AnimEnd()
  {
    animator.SetBool("NoMoney",false);
    Debug.Log("END");
  }

}
