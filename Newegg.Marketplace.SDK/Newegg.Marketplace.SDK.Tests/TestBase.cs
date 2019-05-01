/**
Newegg Marketplace SDK Copyright © 2000-present Newegg Inc. 

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
documentation files (the “Software”), to deal in the Software without restriction, including without limitation the 
rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,
and to permit persons to whom the Software is furnished to do so, subject to the following conditions: 
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software. 
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS 
BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE
OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
**/

using Newegg.Marketplace.SDK.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Newegg.Marketplace.SDK.Tests
{
    public abstract class TestBase
    {
        protected APIConfig USA_Config_XML,  CAN_Config_XML, B2B_Config_XML;
        protected APIClient USAClientXML,  fakeUSAClientXML, CANClientXML, fakeCANClientXML, B2BClientXML, fakeB2BClientXML;

        protected APIConfig USA_Config_JSON, CAN_Config_JSON, B2B_Config_JSON;
        protected APIClient USAClientJSON, fakeUSAClientJSON, CANClientJSON, fakeCANClientJSON, B2BClientJSON, fakeB2BClientJSON;

        protected Dictionary<string, string> settings;

        public TestBase()
        {
            LoadSettings();
            USAClientXML = new APIClient(USA_Config_XML);
            fakeUSAClientXML = new APIClient(USA_Config_XML) { SimulationEnabled = true };            
            CANClientXML = new APIClient(CAN_Config_XML);
            fakeCANClientXML = new APIClient(CAN_Config_XML) { SimulationEnabled = true };

            B2BClientXML = new APIClient(B2B_Config_XML);
            fakeB2BClientXML = new APIClient(B2B_Config_XML) { SimulationEnabled = true };            

            USAClientJSON = new APIClient(USA_Config_JSON);
            fakeUSAClientJSON = new APIClient(USA_Config_JSON) { SimulationEnabled = true };

            CANClientJSON = new APIClient(CAN_Config_JSON);
            fakeCANClientJSON = new APIClient(CAN_Config_JSON) { SimulationEnabled = true };

            B2BClientJSON = new APIClient(B2B_Config_JSON);
            fakeB2BClientJSON = new APIClient(B2B_Config_JSON) { SimulationEnabled = true };
            
        }

        protected void LoadSettings()
        {

            USA_Config_XML = APIConfig.FromJsonFile("configUSA_XML.json");
            CAN_Config_XML = APIConfig.FromJsonFile("configCAN_XML.json");
            B2B_Config_XML = APIConfig.FromJsonFile("configB2B_XML.json");

            USA_Config_JSON = APIConfig.FromJsonFile("configUSA_JSON.json");
            CAN_Config_JSON = APIConfig.FromJsonFile("configCAN_JSON.json");
            B2B_Config_JSON = APIConfig.FromJsonFile("configB2B_JSON.json");
        }
    }
}
