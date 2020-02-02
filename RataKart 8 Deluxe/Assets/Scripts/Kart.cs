using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kart : MonoBehaviour
{
    private const float MAX_SPEED_ANGLE = -20;
    private const float ZERO_SPEED_ANGLE = 230;

    private Transform needleTranform;
    private Transform speedLabelTemplateTransform;

    private float speedMax;
    private float speed;

    private float mouseLife = 100.0f;
    private float cartLife = 100.0f;
    private float wheelLife = 100.0f;
    public Transform Head;
    private void Awake() {
        needleTranform = transform.Find("needle");
        speedLabelTemplateTransform = transform.Find("speedLabelTemplate");
        speedLabelTemplateTransform.gameObject.SetActive(false);

        speed = 0f;
        speedMax = 200f;

        CreateSpeedLabels();
    }

    void Update()
    {
        speed += 30f * Time.deltaTime;
        if (speed > speedMax) speed = speedMax;

        needleTranform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());

    }

    private void CreateSpeedLabels() {
        int labelAmount = 10;
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        for (int i = 0; i <= labelAmount; i++) {
            Transform speedLabelTransform = Instantiate(speedLabelTemplateTransform, transform);
            float labelSpeedNormalized = (float)i / labelAmount;
            float speedLabelAngle = ZERO_SPEED_ANGLE - labelSpeedNormalized * totalAngleSize;
            speedLabelTransform.eulerAngles = new Vector3(0, 0, speedLabelAngle);
            speedLabelTransform.Find("speedText").GetComponent<Text>().text = Mathf.RoundToInt(labelSpeedNormalized * speedMax).ToString();
            speedLabelTransform.Find("speedText").eulerAngles = Vector3.zero;
            speedLabelTransform.gameObject.SetActive(true);
        }

        needleTranform.SetAsLastSibling();
    }

    private float GetSpeedRotation() {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        float speedNormalized = speed / speedMax;

        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "KEZO")
        {
            mouseLife = mouseLife + 5.0f;
        }
        else if (other.transform.tag == "Bandita")
        {
            wheelLife = wheelLife + 5.0f;
        }
        else if (other.transform.tag == "Lata")
        {
            cartLife = cartLife + 5.0f;
        }
        else
        {
            Vector3 hit = other.contacts[0].normal;
            float angle = Vector3.Angle(hit, Vector3.up);
            //Down
            if (!Mathf.Approximately(angle, 0))
            {

                float random = Mathf.Round(Random.Range(0, 2));

                Debug.Log(mouseLife);
                Debug.Log(cartLife);
                Debug.Log(wheelLife);

                if (random == 0)
                {
                    mouseLife = mouseLife - 5.0f;
                    speed -= 90f;
                    if (speed < 0) speed = 0;
                    if (mouseLife < 0) mouseLife = 0;
                }
                if (random == 1)
                {
                    cartLife = cartLife - 5.0f;
                    speed -= 90f;
                    if (speed < 0) speed = 0;
                    if (cartLife < 0) cartLife = 0;
                }
                if (random == 2)
                {
                    wheelLife = wheelLife - 5.0f;
                    speed -= 90f;
                    if (speed < 0) speed = 0;
                    if (wheelLife < 0) wheelLife = 0;
                }

            }
        }
    }
}
