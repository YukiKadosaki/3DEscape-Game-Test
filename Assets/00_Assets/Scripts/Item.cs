using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : CheckableObject
{
    //Start���\�b�h�͐e�ŌĂ΂��

    public override void OnChecked()
    {
        m_Message.text = this.gameObject.name + "���擾����";
        Destroy(this.gameObject);
    }
}
