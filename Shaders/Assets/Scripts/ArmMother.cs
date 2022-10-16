using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ArmMother : MonoBehaviour
{
    Vector3 prevPos;
    Vector3 targetPos;

    public Transform target;
    public float timer;
    public float timeLimit = 2.0f;
    public float range = 20.0f;
    public AnimationCurve curve;

    void Start()
    {
        targetPos = target.position;
        prevPos = targetPos;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        timer += Time.deltaTime;
        if (timer > timeLimit)
        {
            timer = 0.0f;
            prevPos = targetPos;
            targetPos = Random.insideUnitSphere * range;
            if (targetPos.y < 0.0f) targetPos.y = 0;
        }
        float val = curve.Evaluate(timer / timeLimit);
        target.position = Vector3.Lerp(prevPos, targetPos, val);
    }
}
