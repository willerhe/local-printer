using System;
using System.Collections.Generic;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace GprinterDEMO
{
    class Mqtt
    {

        internal static void StartMqttService()
        {
            MqttClient client = new MqttClient("101.132.43.15", 1883, false, null, null, MqttSslProtocols.None);
            string[] topic = { DB.DataSet.Topic };
            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE };
            client.MqttMsgPublishReceived += new MqttClient.MqttMsgPublishEventHandler(messageReceive);
            client.Connect("MqttTest");
            client.Subscribe(topic, qosLevels);
        }

        static void messageReceive(object sender, MqttMsgPublishEventArgs e)
        {
            string msg = "Topic:" + e.Topic + "   Message:" + System.Text.Encoding.Default.GetString(e.Message);
            Dictionary<string, Object> message = new Dictionary<string, Object>();

            Console.WriteLine(msg);
            PrintHelper.SmartPrinter(System.Text.Encoding.Default.GetString(e.Message));
        }
    }
}
