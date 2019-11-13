using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Level : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI explaniationText;
    [SerializeField]
    GyroController gyroController;
    [SerializeField]
    GameObject portal;

    string[] explantions;
    int currentexplanation;

    float holdTimer;
    float holdTimerEnd = .8f;
    // Start is called before the first frame update
    void Start()
    {
        explantions = new string[]
        {
            "in order to change the gravity tilt your phone to the left",
            "now tilt your phone to the right",
            "now tilt your phone down",
            "please move your phone back to a neutral position(tilt the phone back upwards)",
            "go through the portal in order go to the next level"
        };

        portal.SetActive(false);
        currentexplanation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroController.GetDirection == Direction.left && currentexplanation == 0)
        {
            HoldTimer();
        }
        else if (currentexplanation == 0)
        {
            holdTimer = 0;
        }

        if (gyroController.GetDirection == Direction.right && currentexplanation == 1)
        {
            HoldTimer();
        }
        else if (currentexplanation == 1)
        {
            holdTimer = 0;
        }

        if (gyroController.GetDirection == Direction.up && currentexplanation == 2)
        {
            HoldTimer();
        }
        else if (currentexplanation == 2)
        {
            holdTimer = 0;
        }

        if (gyroController.GetDirection == Direction.down && currentexplanation == 3)
        {
            HoldTimer();
        }
        else if (currentexplanation == 3)
        {
            holdTimer = 0;
        }

        if (currentexplanation == 4)
        {
            portal.SetActive(true);
        }
            explaniationText.text = explantions[currentexplanation];
    }

    void HoldTimer()
    {
        holdTimer += Time.deltaTime;
        if (holdTimer >= holdTimerEnd)
        {
            currentexplanation++;
            holdTimer = 0;
        }
    }
}
