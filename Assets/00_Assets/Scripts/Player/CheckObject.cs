//プレイヤーの子オブジェクト（FirstPersonCharacter）に付ける

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObject : MonoBehaviour
{

    Transform m_Transform;

    // Start is called before the first frame update
    void Start()
    {
        m_Transform = transform;
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = new Ray(m_Transform.position, m_Transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100))
        {
            if (hit.collider.CompareTag("CheckableObject") && Input.GetKeyDown(KeyCode.Mouse0))
            {
                hit.collider.GetComponent<CheckableObject>().OnChecked();
            }
        }

    }
}
