/*
© Siemens AG, 2017-2018
Author: Dr. Martin Bischoff (martin.bischoff@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
using UnityEngine;
using RosSharp.RosBridgeClient;

namespace RosSharp.RosBridgeClient
{
    public class joy_publisher_example : UnityPublisher<MessageTypes.Sensor.Joy>
    {
        public float speed_limit = 0.1f;
        private MessageTypes.Sensor.Joy message;      
        public ControllersManager controllerInput;
        private Vector2 righthand_Primary2DAxis;
        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void FixedUpdate()
        {
            UpdateMessage();
        }

        private void InitializeMessage()
        {
            message = new MessageTypes.Sensor.Joy();
            message.header.frame_id = "Unity";
            message.axes = new float[2]; // only x y two axis of joystick
            message.buttons = new int[4]; // A B grip trigger 4 buttons
        }
        private void UpdateMessage()
        {
            righthand_Primary2DAxis = controllerInput.GetComponent<ControllersManager>().getRightPrimary2DAxis();

            message.header.Update();
            message.axes[0] = (float)(righthand_Primary2DAxis.y * speed_limit);
            message.axes[1] = (float)(righthand_Primary2DAxis.x * speed_limit);
            message.buttons[0] = controllerInput.GetComponent<ControllersManager>().getRightPrimaryButton() ? 1 : 0;
            message.buttons[1] = controllerInput.GetComponent<ControllersManager>().getRightSecondaryButton() ? 1 : 0;
            message.buttons[2] = controllerInput.GetComponent<ControllersManager>().getRightGrip() > 0.5 ? 1 : 0;
            message.buttons[3] = controllerInput.GetComponent<ControllersManager>().getRightTrigger() > 0.5 ? 1 : 0;

            Publish(message);
        }

    }
}
