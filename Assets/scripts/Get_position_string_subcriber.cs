using System.Collections;
using System.Collections.Generic;
using RosSharp.RosBridgeClient.MessageTypes.Std;
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class Get_position_string_subcriber : UnitySubscriber<MessageTypes.Std.String>
    {
        public TMPro.TextMeshPro text_obj;
        private string data;
        private bool isMessageReceived;

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        private void ProcessMessage()
        {
            // Access the received Float64MultiArray data
            if (data != null)
            {
                text_obj.text = data;
            }
            isMessageReceived = false;
        }

        protected override void ReceiveMessage(String message)
        {
            // Handle the received String message
            data = message.data;
            isMessageReceived = true;
        }
    }

}