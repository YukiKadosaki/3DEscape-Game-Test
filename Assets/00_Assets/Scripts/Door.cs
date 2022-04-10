using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private Animation m_Animation;
    private bool m_IsClosed = true;

    private void Start()
    {
        m_Animation = this.GetComponent<Animation>();
    }

    public void OpenAndClose()
    {
        if (m_IsClosed)
        {
            Debug.Log("Open");
            m_Animation.Play();
        }
        else
        {
            Debug.Log("Close");
        }

        //äJï¬èÛë‘ÇÕîΩì]
        m_IsClosed = !m_IsClosed;
    }
}
