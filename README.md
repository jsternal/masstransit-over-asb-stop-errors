# masstransit-over-asb-stop-errors
When stopping a MassTransit 5.5.4 bus running on Azure Service Bus, I'm seeing the following exception (the receiver name and session vary):

```
MassTransit.AzureServiceBusTransport.Transport.Receiver Error: 0 : Exception received on receiver: sb://namespace.servicebus.windows.net/DEVJSTERNAL_MassTransitTest_bus_951oyydbbhypto3mbdmteikj8u?express=true&autodelete=300 during Receive, System.InvalidOperationException: The AMQP object session11 is closing. Operation 'attach' cannot be performed.
   at Microsoft.ServiceBus.Messaging.Amqp.AmqpSession.AttachLink(AmqpLink link)
   at Microsoft.ServiceBus.Messaging.Amqp.AmqpLink.AttachTo(AmqpSession session)
   at Microsoft.ServiceBus.Messaging.Amqp.AmqpMessagingFactory.OpenEntityLinkAsyncResult`1.CreateAmqpLink(AmqpLinkSettings settings, AmqpSession session)
   at Microsoft.ServiceBus.Messaging.Amqp.AmqpMessagingFactory.OpenLinkAsyncResult`1.<GetAsyncSteps>d__39.MoveNext()
   at Microsoft.ServiceBus.Messaging.IteratorAsyncResult`1.EnumerateSteps(CurrentThreadType state)
   at Microsoft.ServiceBus.Messaging.IteratorAsyncResult`1.StepCallback(IAsyncResult result)
   at Microsoft.ServiceBus.Common.AsyncResult.AsyncCompletionWrapperCallback(IAsyncResult result)
--- End of stack trace from previous location where exception was thrown ---
   at Microsoft.ServiceBus.Common.AsyncResult.End[TAsyncResult](IAsyncResult result)
   at Microsoft.ServiceBus.Messaging.Amqp.AmqpMessagingFactory.EndOpenReceiveEntity(IAsyncResult result)
   at Microsoft.ServiceBus.Messaging.Amqp.AmqpMessageReceiver.EndCreateLink(IAsyncResult result)
   at Microsoft.ServiceBus.Messaging.Amqp.FaultTolerantObject`1.CreateAsyncResult.<>c.<GetAsyncSteps>b__5_1(CreateAsyncResult thisPtr, IAsyncResult r)
   at Microsoft.ServiceBus.Messaging.IteratorAsyncResult`1.StepCallback(IAsyncResult result)
--- End of stack trace from previous location where exception was thrown ---
   at Microsoft.ServiceBus.Common.AsyncResult.End[TAsyncResult](IAsyncResult result)
   at Microsoft.ServiceBus.Common.AsyncResult`1.End(IAsyncResult asyncResult)
   at Microsoft.ServiceBus.Messaging.Amqp.FaultTolerantObject`1.OnEndCreateInstance(IAsyncResult asyncResult)
   at Microsoft.ServiceBus.Messaging.SingletonManager`1.EndGetInstance(IAsyncResult asyncResult)
   at Microsoft.ServiceBus.Messaging.Amqp.AmqpMessageReceiver.ReceiveAsyncResult.<>c.<GetAsyncSteps>b__15_1(ReceiveAsyncResult thisPtr, IAsyncResult r)
   at Microsoft.ServiceBus.Messaging.IteratorAsyncResult`1.StepCallback(IAsyncResult result)
--- End of stack trace from previous location where exception was thrown ---
   at Microsoft.ServiceBus.Common.AsyncResult.End[TAsyncResult](IAsyncResult result)
   at Microsoft.ServiceBus.Messaging.Amqp.AmqpMessageReceiver.OnEndTryReceive(IAsyncResult result, IEnumerable`1& messages)
   at Microsoft.ServiceBus.Messaging.MessageReceiver.RetryReceiveAsyncResult.<>c.<GetAsyncSteps>b__15_3(RetryReceiveAsyncResult thisPtr, IAsyncResult r)
   at Microsoft.ServiceBus.Messaging.IteratorAsyncResult`1.StepCallback(IAsyncResult result)
--- End of stack trace from previous location where exception was thrown ---
   at Microsoft.ServiceBus.Common.AsyncResult.End[TAsyncResult](IAsyncResult result)
   at Microsoft.ServiceBus.Messaging.MessageReceiver.RetryReceiveAsyncResult.TryReceiveEnd(IAsyncResult r, IEnumerable`1& messages)
   at Microsoft.ServiceBus.Messaging.MessageReceiver.EndTryReceive(IAsyncResult result, IEnumerable`1& messages)
   at Microsoft.ServiceBus.Messaging.MessageReceiver.EndReceive(IAsyncResult result)
   at Microsoft.ServiceBus.Messaging.MessageReceivePump.PumpAsyncResult.<>c.<GetAsyncSteps>b__7_3(PumpAsyncResult thisPtr, IAsyncResult r)
   at Microsoft.ServiceBus.Messaging.IteratorAsyncResult`1.StepCallback(IAsyncResult result)
```


This is console app reproduces the problem; just provide a valid ASB connection string in the app.config's `Microsoft.ServiceBus.ConnectionString` key.
