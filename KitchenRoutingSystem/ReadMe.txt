
Requirement:

Order is placed from different POS, the order should be routed to the respective kitchens.
Example: 
We have Kitchen Fry, Drink, icecreams etc...
Based on items in an order, the order should be split and routed to respective kitchen.


Assumption:

1. Database is not used, therefore I am not using any DTO. Application can be tested using the raw json through swagger
2. No unit test and integration test is written on this POC code.
2. KitchenRoutingSystem Project can be launch through console/IIS and data can be psoted to azure service bus.
3. I have used two subscription service which are simple console projects (DrinkKitchenService and FryKitchen Service).
4. In real time we can have azure function/trigger which can read the message from topics in azure bus, 
We may use redis cache for this.  I have used simple console subscription for simplicity.


1. Azure Bus is used for Message Queuee(Topic)
2. I have used topics and filter to route the items for a particular order to respective kitchen
3. Fault Tolerance, Session, Duplcate Message detections and Dead lettering is not handled


Please follow below steps to configure the app.

Note: Steps 1-4 can be done through C# code also, but I prefered through Azure Portal

1. Create Namespace in Azure Survice bus
2. Add Topic: Topic Name >orderrouting
3. Create Kitchen Subscription .eg. Fry Drink etc.
4. Write the SqlFilter Rule Like a> sys.Label='Drink' b> sys.Label='Fry' etc.


Settings in Appsetting.json

"AzureServiceBus": {
    "ConnectionString": "Endpoint=sb://kitchenrouting.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=zmr96tIrl/HelCFSxp+vM082Ib+IxAvFzkEywDMVDlM=",
    "Topicname": "orderrouting"
  }

> Swagger can be used to send the Order request:

PayLoad Example:

{
  "id": 1,
  "customerId": 1,
  "customer": {
    "id": 1,
    "name": "abc",
    "phoneNumber": "54545",
    "orders": [
      null
    ]
  },
  "orderDetails": [
    {
      "id": 1,
      "quantity": 2,
      "orderId": 1,
      "itemId": 1,
      "item": {
        "id": 1,
        "name": "French Fry",
        "price": 10,
        "kitchenId": 1,
        "kitchen": {
          "id": 1,
          "name": "Fry",
          "items": [
            null
          ]
        }
      }
    },
 {
      "id": 2,
      "quantity": 1,
      "orderId": 1,
      "itemId": 2,
      "item": {
        "id": 2,
        "name": "Coke",
        "price": 111,
        "kitchenId": 2,
        "kitchen": {
          "id": 2,
          "name": "Drink",
          "items": [
            null
          ]
        }
      }
}
  ]
}