using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform camTranform;
    private float shakeDur = 1f, shakeAmount = 0.05f, decreaseFactor = 1.5f;

    private Vector3 originPos;

    private void Start()
    {
        camTranform = GetComponent<Transform>();
        originPos = camTranform.localPosition;
    }
    private void Update()
    {
        if (shakeDur > 0)
        {
            camTranform.localPosition = originPos + Random.insideUnitSphere * shakeAmount;
            shakeDur -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDur = 0;
            camTranform.localPosition = originPos;
        }
    }
}
