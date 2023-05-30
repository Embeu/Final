using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Target;               // ī�޶� ����ٴ� Ÿ��

    private float offsetX = 0f;            // ī�޶��� x��ǥ
    private float offsetY = 30.0f;           // ī�޶��� y��ǥ
    private float offsetZ = -10.0f;          // ī�޶��� z��ǥ
    private float CameraSpeed = 10.0f;       // ī�޶��� �ӵ�

    Vector3 TargetPos;                      // Ÿ���� ��ġ

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameObject.FindWithTag("Player"))
        {
            return;
        }

        // Ÿ���� x, y, z ��ǥ�� ī�޶��� ��ǥ�� ���Ͽ� ī�޶��� ��ġ�� ����
        TargetPos = new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ
            );

        // ī�޶��� �������� �ε巴�� �ϴ� �Լ�(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
    }
}
