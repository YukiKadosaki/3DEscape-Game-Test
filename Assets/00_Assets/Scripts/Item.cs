using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : CheckableObject
{
    //Startメソッドは親で呼ばれる

    public override void OnChecked()
    {
        m_Message.text = this.gameObject.name + "を取得した";
        Destroy(this.gameObject);
    }
}
