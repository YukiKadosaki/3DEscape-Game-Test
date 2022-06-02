using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    private bool m_IsOpenning = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void subroutine()
    {
        Debug.Log("サブルーチンコール");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            m_IsOpenning = !m_IsOpenning;
            if (m_IsOpenning)
            {
                Time.timeScale = 0;
                Debug.Log("MenuOpen");
            }
            else
            {
                Time.timeScale = 1;
            }
            
        }
    }
}
