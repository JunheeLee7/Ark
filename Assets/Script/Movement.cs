using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement : Characters
{
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float rotSpeed = 360.0f;

    Coroutine coMove = null;
    Coroutine coRot = null;

    public void MovePos(Vector3 pos, UnityAction done = null)
    {
        if(coMove != null)
        {
            StopCoroutine(coMove);
        }
        coMove = StartCoroutine(Moving(pos, done));
    }

    public void SpacePos()
    {
        StopAllCoroutines();
        StartCoroutine(Spaceing());
    }

    IEnumerator Moving(Vector3 pos, UnityAction done)
    {
        Vector3 dir = pos - transform.position;
        float dist = dir.magnitude;
        dir.Normalize();

        if(coRot != null)
        {
            StopCoroutine (coRot);
        }
        coRot = StartCoroutine(Rotating(dir));

        if(myAnim.GetBool("isSpace") == true)
        {
            myAnim.SetBool("isSpace", false);
        }
        myAnim.SetBool("isRun", true);

        while(dist > 0.0f)
        {
            float delta = Time.deltaTime * moveSpeed;

            if(delta > dist)
            {
                delta = dist;
            }
            dist -= delta;
            transform.Translate(dir * delta, Space.World);
            yield return null;
        }

        myAnim.SetBool("isRun", false);
        done?.Invoke();
    }

    IEnumerator Rotating(Vector3 dir)
    {
        float angle = Vector3.Angle(transform.forward, dir);
        float rotDir = 1.0f;

        if(Vector3.Dot(transform.right, dir) < 0.0f)
        {
            rotDir = -1.0f;
        }

        while(angle > 0.0f)
        {
            float delta = Time.deltaTime * rotSpeed;
            if(delta > angle)
            {
                delta = angle;
            }
            transform.Rotate(Vector3.up * rotDir * delta, Space.World);
            angle -= delta;
            yield return null;
        }
    }

    IEnumerator Spaceing()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 mop = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.y));
        transform.LookAt(mop);

        myAnim.SetBool("isRun", false);
        myAnim.SetBool("isSpace", true);

        yield return new WaitForSeconds(0.4f);

        myAnim.SetBool("isSpace", false);
        transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
