using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CheckableObject : MonoBehaviour
{

    [SerializeField, Tooltip("�N���b�N���ꂽ�Ƃ��Ƀ��b�Z�[�W��\�����邩�ǂ���")]
    private bool m_MessageDisplayFlag;

    protected Text m_Message;

    virtual protected void Start()
    {
        GameObject txtObj;
        if ((txtObj = GameObject.FindGameObjectWithTag("Message")) == null) 
            Debug.LogError("Message�^�O�̕t�����I�u�W�F�N�g������܂���");
        if ((m_Message = txtObj.GetComponent<Text>()) == null) 
            Debug.LogError("Message�I�u�W�F�N�g��Text�R���|�[�l���g������܂���");
    }

    public abstract void OnChecked();
}
