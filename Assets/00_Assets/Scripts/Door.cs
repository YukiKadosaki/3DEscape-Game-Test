using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : CheckableObject
{

    private Animator m_Animator;
    private bool m_IsClosed = true;

    protected override void Start()
    {
        base.Start();
        m_Animator = this.GetComponent<Animator>();
    }

    public override void OnChecked()
    {

        //�A�j���[�V�������Ȃ�I��
        if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1) return;

        if (m_IsClosed)
        {
            Debug.Log("Open");
            m_Animator.Play("DoorOpen");
            m_Message.text = "�h�A���J����";
        }
        else
        {
            Debug.Log("Close");
            m_Animator.Play("DoorClose");
            m_Message.text = "�h�A��߂�";
        }

        //�J��Ԃ͔��]
        m_IsClosed = !m_IsClosed;
    }
}
