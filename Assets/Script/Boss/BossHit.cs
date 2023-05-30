using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHit : MonoBehaviour
{
    private BossScript bossScript;
    private BossStateInfo bossState;

    void Start()
    {
        bossScript = GameObject.Find("Red").GetComponent<BossScript>();
        bossState = bossScript.bossState;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            ContactPoint contact = collision.contacts[0];     // ���� ����
            GameObject collidedObject = collision.gameObject; // �Ѿ�
            float hitDamage = collidedObject.GetComponent<bullet>().damage;

            if (contact.thisCollider.CompareTag("BossHead"))
            {
                Debug.Log("�Ӹ� ��Ʈ");
                bossState.HP -= hitDamage;
            }
            else if (contact.thisCollider.CompareTag("LeftShoulder"))
            {
                Debug.Log("���� / ���ʾ�� ��Ʈ");
                bossState.HP -= hitDamage;
                bossState.LeftShoulderHP -= hitDamage;
                if (bossState.LeftShoulderHP < 0)
                {
                    GameObject shoulderObj = GameObject.Find("L_Shoulder01");
                    Vector3 scale = shoulderObj.transform.localScale;
                    scale.x = 0f;
                    shoulderObj.transform.localScale = scale;
                }
            }
            else if (contact.thisCollider.CompareTag("RightShoulder"))
            {
                Debug.Log("���� / ������ ��� ��Ʈ");
                bossState.HP -= hitDamage;
                bossState.RightShoulderHP -= hitDamage;
                if (bossState.RightShoulderHP < 0)
                {
                    GameObject shoulderObj = GameObject.Find("R_Shoulder01");
                    Vector3 scale = shoulderObj.transform.localScale;
                    scale.x = 0f;
                    shoulderObj.transform.localScale = scale;
                }
            }
            else if (contact.thisCollider.CompareTag("BossBody"))
            {
                Debug.Log("���� ��Ʈ");
                bossState.HP -= hitDamage;
            }

            Debug.Log("���� �� : "+bossState.HP);
            // �浹�� �Ѿ� ����
            Destroy(collidedObject);

            // ������ HP üũ
            if (bossState.HP <= 0)
            {
                //bossScript.Die();
            }

        }
    }
}
