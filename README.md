# NewEgg Marketplace SDK for .Net

Newegg Marketplace SDK(C#) is a library to help .Net programmers easily integrate their application with the Newegg Marketplace API.  Included are definitions for the data objects models to create the request and resolve the response. The logger and retry mechanism can be customized to your requirements.

To use the SDK to communicate with the Newegg API, you need to be a registered seller and have an 'API Key(Authorization)' and 'Secret Key' by mail Datafeeds@newegg.com. Put this information into a JSON file and load the setting using the APIConfig.FromJsonFile method. Without the 'API Key(Authorization)' and 'Secret Key' you can run the test project in Simulation Mode. This is provided to help you understand the SDK before actual use.

The solution contains 2 library projects: Newegg.Marketplace.SDK.Base and Newegg.Marketplace.SDK. The first one is the framework of the SDK, and the second one is the business logic model and interface to various API. The code is based on .NET Standard 2.0, you can build it with .Net framework 4.6 or .Net Core 2.1.


## Target Frameworks  
* .NET Standard 2.0 

## Installation  
    The package is on Nuget. You can install it with the Nuget Package Manager, search for 'newegg.marketplace.sdk'. You can also install it with the following tools:    
- Package Manager:  
    `Install-Package Newegg.Marketplace.SDK -Version 0.1.1-beta`    
- .Net CLI       
    `Install-Package Newegg.Marketplace.SDK -Version 0.1.1-beta`    
- PackageReference  
    `<PackageReference Include="Newegg.Marketplace.SDK" Version="0.1.1-beta" />`    
- Paket CLI  
    `paket add Newegg.Marketplace.SDK --version 0.1.1-beta`


## build

You can download the zip file and build it for your target frameworks(.Net framework4.6 or .Net core2.1).
You can choose manually build it and link library from your project or direct include the project to your solution.
We recommend using Visual Studio 2017 or later. You can choose to build it with the command following too.
- To build  
    `dotnet build Newegg.Marketplace.SDK`    
- Nuget library
    The library Dependents on 'Newtonsoft.Json(12.0.1)' and 'NLog(4.6.2)'.
    

## Q&A
- How to use the SDK?
1. We recommed setting these infomation in a json file as below. 
```json
{    
  "SellerID": "****",
  "Credentials": {
    "Authorization": "********************************",
    "SecretKey": "*******-****-****-****-************"
  },
  "Connection": {
    "RequestTimeoutMs": 30000,
    "AttemptsTimes": 5,
    "RetryIntervalMs": 1000
  },
  "APIFormat": "XML",
  "Platform": "CAN"
}
```

2. load the configuration to a APIConfig object.
```csharp
APIConfig config = APIConfig.FromJsonFile(PathOfTheJSONConfigFile);
```
3. Create a APIClient with the config.
```csharp
APIClient client = new APIClient(config);
```
4. Create the APICall object with the APIClien.
```csharp
OrderCall ordercall = new OrderCall(client);
```
5. Use the APICall object to call API.
```csharp
var orderstatus = await ordercall.GetOrderStatus("105137040", 304);
```    

- What's the settings in the Config?
    * SellerID :  The 4-character Seller ID. Required.
    * Credentials.Authorization: The API Key get from datafeeds@newegg.com. Required.
    * Credentials.SecretKey: The Secret Key get from datafeeds@newegg.com. Required.
    * Connection.RequestTimeoutMs: The number of milliseconds the system connection timed out. Optional, Default:
    * Connection.AttemptsTimes: Number of retries after a failed connection. Optional, Default:
    * Connection.RetryIntervalMs: The number of milliseconds between retry attempts. Optional, Default:
    * BaseUrl: The base url of the Newegg marketplace API. Optional, Default: https://apis.newegg.com/marketplace/
    * APIFormat: Content type used to call API.  The options are XML and Json. Optional, Default: XML.
    * Platform: The platfrom of seller: There are three options: 
        * USA: seller on www.newegg.com
        * B2B: seller on www.neweggbussiness.com
        * CAN: seller on www.newegg.ca
     Optional, Default: USA.
    
    

- How to get the API key and Secret Key?
    1. Send the request to Datafeeds@newegg.com from the seller default email address.
    2. The message should include seller name or default email address.
    Newegg Marketplace team will process all requests in 24 hours.  

- NLog configuration file location and how to customize log
Please refer https://github.com/NLog/NLog/wiki/Configuration-file#configuration-file-locations


## Modules

### Item
- Item Management  
    https://developer.newegg.com/newegg_marketplace_api/item_management/

### Seller
- Seller Management  
    https://developer.newegg.com/newegg_marketplace_api/seller_management/

### Order
- Order Management  
    https://developer.newegg.com/newegg_marketplace_api/order_management/
    
### Shipping
- Newegg Shipping Label Service  
    https://developer.newegg.com/newegg_marketplace_api/newegg_shipping_label_service/

### Other
- Verify Service Status  
    https://developer.newegg.com/newegg_marketplace_api/verify_service_status/

### SBN
- Shipped by Newegg Management  
    https://developer.newegg.com/newegg_marketplace_api/sbn_shipped_by_newegg_management/
    
### DataFeed
- DataFeed Management  
    https://developer.newegg.com/newegg_marketplace_api/datafeed_management/

### Report
- Reports Management  
    https://developer.newegg.com/newegg_marketplace_api/reports_management/

### RMA
- RMA(Return Merchandise Authorization) Management  
    https://developer.newegg.com/newegg_marketplace_api/rma_management/
