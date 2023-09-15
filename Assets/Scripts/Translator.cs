using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Translator : MonoBehaviour
{

    private float timeLeft;

        void Start()
        {
            timeLeft = 15;
        }

        void Update()
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft >10 && timeLeft <=15)
            {
                transform.Translate(Vector3.forward * 3 * Time.deltaTime);
            }
            else if (timeLeft >5 && timeLeft <=10)
            {
                transform.Translate(-Vector3.forward * 3 * Time.deltaTime);
            }
            else 
            {
                transform.Translate(Vector3.forward * 3 * Time.deltaTime);
            }
            transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
        }
}
