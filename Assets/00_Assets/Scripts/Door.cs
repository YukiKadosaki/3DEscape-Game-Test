using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private Animator m_Animator;
    private bool m_IsClosed = true;

    private void Start()
    {
        m_Animator = this.GetComponent<Animator>();
    }

    public void OpenAndClose()
    {

        //アニメーション中なら終了
        if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1) return;

        if (m_IsClosed)
        {
            Debug.Log("Open");
            m_Animator.Play("DoorOpen");
        }
        else
        {
            Debug.Log("Close");
            m_Animator.Play("DoorClose");
        }

        //開閉状態は反転
        m_IsClosed = !m_IsClosed;
    }
}
