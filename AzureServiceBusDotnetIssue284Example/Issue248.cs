using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using System;
using System.Threading.Tasks;

namespace AzureServiceBusDotnetIssue284Example
{
    public class Issue248
    {
        public async static Task Reproduce()
        {
            string azureServiceBusConnectionString = "";
            string queueName = "";

            IQueueClient queueClient = new QueueClient(azureServiceBusConnectionString
                , queueName, ReceiveMode.PeekLock);
            IMessageReceiver rec = new MessageReceiver(azureServiceBusConnectionString
                , queueName, ReceiveMode.PeekLock);

            await queueClient.SendAsync(new Message(new byte[300]) { MessageId = Guid.NewGuid().ToString() });


            queueClient = new QueueClient(azureServiceBusConnectionString
                , queueName, ReceiveMode.PeekLock);
            rec = new MessageReceiver(azureServiceBusConnectionString
                , queueName, ReceiveMode.PeekLock);


            var res = await rec.ReceiveAsync();

            queueClient = new QueueClient(azureServiceBusConnectionString
                , queueName, ReceiveMode.PeekLock);
            rec = new MessageReceiver(azureServiceBusConnectionString
                , queueName, ReceiveMode.PeekLock);


            await rec.CompleteAsync(res.SystemProperties.LockToken);

        }
    }
}
