using UnityEngine;
using RosSharp.RosBridgeClient.MessageTypes.Std;

namespace RosSharp.RosBridgeClient
{
    public class keyboard_floatarray_publisher_example : UnityPublisher<MessageTypes.Std.Float64MultiArray>
    {
        private Float64MultiArray message;
        public float speed_limit = 0.1f;
        protected override void Start()
        {
            base.Start();
            message = new Float64MultiArray();
            // Initialize other message properties if needed
        }

        private void FixedUpdate()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            double[] data = {verticalInput * speed_limit, horizontalInput * speed_limit};
            // Debug.Log("data: " + string.Join(", ", data));
            PublishMessage(data);
        }

        // Publish the message when needed
        private void PublishMessage(double[] data){
    
            // Populate the data in your Float64MultiArray here
            // For example:
            message.data = data;

            Publish(message);
        }
    }
}