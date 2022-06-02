using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private const int canvas_width = 1920;
    private const int canvas_height = 1080;


    public static MenuManager instance;
    private bool m_IsOpenning = false;

    [SerializeField]
    private GameObject m_Canvas;
    [SerializeField]
    private RectTransform m_MousePointer;
    [SerializeField]
    private float m_MouseSpeed = 50;//マウスの移動速度

    private Vector2 m_MousePositionBefore;//前フレームのマウス座標の差を計るため

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

    private void Start()
    {
        if (!m_Canvas)
            Debug.LogError("インスペクターからキャンバスを設定してください");
        if(!m_MousePointer)
            Debug.LogError("インスペクターからマウスポインタ画像を設定してください");

        m_Canvas.SetActive(false);
        m_MousePositionBefore = Vector2.zero;
    }

    private void Update()
    {
        TryOpenAndCloseMenu();
        
        if (!m_IsOpenning)
            return;

        TryDrawMousePointer();
    }

    /// <summary>
    /// キー入力を検査してメニューの開閉をする
    /// </summary>
    private void TryOpenAndCloseMenu()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            m_IsOpenning = !m_IsOpenning;
            if (m_IsOpenning)
            {
                Time.timeScale = 0;
                m_Canvas.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                m_Canvas.SetActive(false);
            }

        }
    }

    /// <summary>
    /// マウスポインタの座標を計算し、表示する
    /// </summary>
    private void TryDrawMousePointer()
    {
        Vector2 mouseDeltaPosition = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        float nextMouseX = m_MousePointer.position.x + mouseDeltaPosition.x * m_MouseSpeed;
        float nextMouseY = m_MousePointer.position.y + mouseDeltaPosition.y * m_MouseSpeed;
        Vector2 newPosition = m_MousePositionBefore;

        if (0 <= nextMouseX && nextMouseX <= canvas_width)
        {
            newPosition.x = nextMouseX;
        }

        if (0 <= nextMouseY && nextMouseY <= canvas_height)
        {
            newPosition.y = nextMouseY;
        }
        m_MousePointer.position = newPosition;

        m_MousePositionBefore = newPosition;
    }
}
