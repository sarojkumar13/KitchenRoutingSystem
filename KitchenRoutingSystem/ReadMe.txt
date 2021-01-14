1. Azure Bus is used for Message Queuee
2. I have used topics and filter to route the items for a particular order to respective kitchen
3. Fault Tolerance, Session, Duplcate Message detections and Dead lettering is not handled


Needs to be done to work this application:

Note: Steps 1-4 can be done through C# code also, but I presered through Azure Portal

1. Create Namespace in Azure Survice bus
2. Add Topic: Topic Name >orderrouting
3. Create Kitchen Subscription .eg. Fry Drink etc.
4. Write the SqlFilter Rule Like a> sys.Label='Drink' b> sys.Label='Fry' etc.


Settings in Appsetting.json

 "ConnectionStrings": {
    "AzureServiceBus": "Add Connection String"
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