using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Movement
{
    public LayerMask landMask;

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
            OnSpace();
        }
    }
    public void OnMove(Vector3 pos)
    {
        StopAllCoroutines();
        MovePos(pos);
    }

    public void OnAttack()
    {

    }
    
    public void OnSpace()
    {
        StopAllCoroutines();
        SpacePos();
    }
}
