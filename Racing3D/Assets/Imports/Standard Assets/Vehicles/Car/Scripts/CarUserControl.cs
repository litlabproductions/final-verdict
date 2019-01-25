using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public float speed;

        public float currentSpeed;
        private Rigidbody carRB;

        private int floorMask;
        private float camRayLength = 100f;

        private bool isDead = false;

        public Text arrestText;
        public Text arrestTimerText;

        public Text speedometerTickerText;


        [SerializeField]
        private float arrestTimer;


        private float currentArrestTimer;
        private float h;

        private GameObject leftButtonObj;
        private GameObject rightButtonObj;

        private Button leftButton;
        private Button rightButton;

        private void Awake()
        {
            floorMask = LayerMask.GetMask("Ground");

            // get the car controller
            m_Car = GetComponent<CarController>();

          // float n =  m_Car.CurrentSpeed;
            //speed = 15.0f;
        
            speed = 16.0f;

            carRB = GetComponent<Rigidbody>();

           // arrestText.gameObject.SetActive(false);
           // arrestTimerText.gameObject.SetActive(false);

            currentArrestTimer = arrestTimer;


            leftButtonObj = GameObject.Find("LeftButton");
            rightButtonObj = GameObject.Find("RightButton");

            leftButton = leftButtonObj.GetComponent<Button>();
            rightButton = rightButtonObj.GetComponent<Button>();
        }


        private void FixedUpdate()
        {


            // pass the input to the car!
            if (Application.platform == RuntimePlatform.WindowsPlayer)
                h = CrossPlatformInputManager.GetAxis("Horizontal");

          

            float v = CrossPlatformInputManager.GetAxis("Vertical");
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");


            if (!isDead)
                m_Car.Move(h, speed * Time.deltaTime, 0.0f, handbrake);

            // Speedometer
            speedometerTickerText.text = ((int)m_Car.CurrentSpeed).ToString(); 


            if (m_Car.CurrentSpeed < 4.0f && currentArrestTimer > 0.0f)
            {
                arrestText.gameObject.SetActive(true);  
               arrestTimerText.gameObject.SetActive(true);
                currentArrestTimer -= Time.deltaTime;
                arrestTimerText.text = ((int)currentArrestTimer).ToString();

                StartCoroutine(CallCops());
            }
            else
            { 
               arrestText.gameObject.SetActive(false);
               arrestTimerText.gameObject.SetActive(false);

                if (!isDead)
                    currentArrestTimer = arrestTimer;
            }

            if (m_Car.CurrentSpeed >= 4.0f)
            {
                currentArrestTimer = arrestTimer;
                m_Car.hasCollisionSoundPLayed = false;
            }
 

        }

        public void MoveLeft()
        {
            h = -1.0f;
        }
        
        public void MoveRight()
        {
            h = 1.0f;
        }

        public void MoveStraight()
        {
            h = 0.0f;
        }

        IEnumerator CallCops()
        {
            Debug.Log("Cops are being called!");
            yield return new WaitForSeconds(arrestTimer);
            if (m_Car.CurrentSpeed < 4.0f)
            {
                isDead = true;
                StartCoroutine(m_Car.Death());
               // GetComponent<CarController>().enabled = false;
            }
        }
    }
}



