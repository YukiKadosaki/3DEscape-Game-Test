//プレイヤーの子オブジェクト（FirstPersonCharacter）に付ける

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObject : MonoBehaviour
{
    [SerializeField]
    private GameObject m_LinePrefab;

    Transform m_Transform;
    private GameObject m_Line;
    private LineRenderer m_LineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        m_Transform = transform;
        // Lineオブジェクトの生成
        m_Line  = Instantiate(m_LinePrefab,
                            m_Transform.localPosition,
                            Quaternion.identity) as GameObject;

        // LineRenderer取得
        m_LineRenderer = m_Line.GetComponent<LineRenderer>();
        
        m_LineRenderer.positionCount = 2;//始点と終点
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = new Ray(m_Transform.position, m_Transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100))
        {
            m_LineRenderer.SetPosition(0, hit.point);
            m_LineRenderer.SetPosition(1, hit.point + Vector3.up * 0.1f);
            if (hit.collider.CompareTag("CheckableObject") && Input.GetKeyDown(KeyCode.Mouse0))
            {
                hit.collider.GetComponent<Door>().OpenAndClose();
            }
        }
        else
        {
            m_LineRenderer.SetPosition(0, Vector3.zero);
            m_LineRenderer.SetPosition(1, Vector3.zero);
        }

    }
}
