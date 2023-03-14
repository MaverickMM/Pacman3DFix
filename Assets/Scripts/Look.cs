using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Kawaiisun.SimpleHostle
{
    public class Look : MonoBehaviour
    {
        public static bool cursorLocked;
        
        public Transform Player;
        public Transform cams;

        public float xSensitivity;
        public float ySensitivity;
        public float maxAngle;

        private Quaternion camCenter;
    // Start is called before the first frame update
        void Start()
        {
            camCenter = cams.localRotation;
        }

    // Update is called once per frame
        void Update()
        {
            if (!Pause.GameIsPaused)
            {
                // Your code here

                SetY();
                SetX();

                UpdateCursorLock();
            }
        }

        void SetY ()
        {
            float t_input = Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;
            Quaternion t_adj = Quaternion.AngleAxis(t_input, -Vector3.right);
            Quaternion t_delta = cams.localRotation * t_adj;

            if (Quaternion.Angle(camCenter, t_delta) < maxAngle)
            {
                cams.localRotation = t_delta;
            }
        }

        void SetX ()
        {
            float t_input = Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
            Quaternion t_adj = Quaternion.AngleAxis(t_input, Vector3.up);
            Quaternion t_delta = Player.localRotation * t_adj;
            Player.localRotation = t_delta;
        }

        void UpdateCursorLock ()
        {
            if(cursorLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    cursorLocked = false;
                }
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    cursorLocked = true;
                }
            }
        }
    }
}
