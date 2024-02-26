using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Movement
{
    public LayerMask landMask;

    private bool isCool = false;
    public float coolDuriation = 4.6f;

    private float attackCount = 0.5f;

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 999.0f, landMask))
            {
                if(hit.transform.gameObject.layer == 6)
                {
                    OnMove(hit.point);
                }
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!isCool)
            {
                OnSpace();
            }
        }
        else if(Input.GetMouseButtonDown(0))
        {
            if(attackCount >= 0.0f && attackCount <= 1.0f)
            {
                attackCount = 1.5f;
            }
            else if(attackCount >= 1.1f && attackCount <= 2.0f)
            {
                attackCount = 2.5f;
            }
            else if(attackCount >= 2.1f && attackCount < 3.0f)
            {
                attackCount = 0.5f;
            }
            OnAttack(attackCount);
        }
    }
    
    public void OnMove(Vector3 pos)
    {
        MovePos(pos);
    }

    public void OnSpace()
    {
        SpacePos();
        StartCoroutine(Cooling(coolDuriation));
    }

    IEnumerator Cooling(float t)
    {
        isCool = true;
        Debug.Log("W");
        
        yield return new WaitForSeconds(t);

        isCool = false;
        Debug.Log("Z");
    }
    
}
