using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeAmount;
    public float shakeTime;
    public float shakeLerpTime;

    float shakePercent;
    float shakeDuration;

    Vector3 standardPostion;

    void Awake()
    {
        standardPostion = transform.position;
    }

    public void ShakeCam()
    {
        if (shakeCoroutine != null)
            StopCoroutine(shakeCoroutine);


        shakeDuration = shakeTime;
        shakeCoroutine = StartCoroutine(Shake());
    }

    Coroutine shakeCoroutine = null;

    IEnumerator Shake()
    {
        while (shakeDuration > 0f)
        {
            Vector3 amountPositionVec = Random.insideUnitSphere * shakeAmount;
            Vector3 amountRotationVec = Random.insideUnitSphere * shakeAmount;
            amountPositionVec.z = 0;
            amountRotationVec.x = amountRotationVec.y = 0;

            shakePercent = shakeAmount * shakePercent;
            shakeDuration -= Time.deltaTime; 

            transform.position = Vector3.Lerp(transform.position, amountPositionVec, Time.deltaTime * shakeLerpTime);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(amountRotationVec), Time.deltaTime * shakeLerpTime);

            yield return null;
        }

        transform.position = standardPostion;
        transform.localRotation = Quaternion.identity;
        shakeCoroutine = null;
    }

}
