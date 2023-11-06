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
using std_srvs = RosSharp.RosBridgeClient.MessageTypes.Std;

namespace RosSharp.RosBridgeClient
{
    [RequireComponent(typeof(RosConnector))]
    public abstract class UnityServiceClient<Tin, Tout> : MonoBehaviour where Tin : Message where Tout : Message
    {
        public string servicename;

        private RosConnector rosConnector;

        protected virtual void Start()
        {
            rosConnector = GetComponent<RosConnector>();
            
        }

        protected void CallService(ServiceResponseHandler<Tout> serviceResponseHandler, Tin serviceArguments)
        {
            rosConnector.RosSocket.CallService<Tin, Tout>(servicename, serviceResponseHandler, serviceArguments);
        }

        
    }
}