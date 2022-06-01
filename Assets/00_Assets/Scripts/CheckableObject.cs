using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CheckableObject : MonoBehaviour
{

    [SerializeField, Tooltip("クリックされたときにメッセージを表示するかどうか")]
    private bool m_MessageDisplayFlag;

    protected Text m_Message;

    virtual protected void Start()
    {
        GameObject txtObj;
        if ((txtObj = GameObject.FindGameObjectWithTag("Message")) == null) 
            Debug.LogError("Messageタグの付いたオブジェクトがありません");
        if ((m_Message = txtObj.GetComponent<Text>()) == null) 
            Debug.LogError("MessageオブジェクトにTextコンポーネントがありません");
    }

    public abstract void OnChecked();
}
