﻿using Newtonsoft.Json;
using Paydock_dotnet_sdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paydock_dotnet_sdk.Services
{
    public class Customers
    {
        protected IServiceHelper _serviceHelper;

        /// <summary>
        /// Service locator style constructor
        /// </summary>
        public Customers()
        {
            _serviceHelper = new ServiceHelper();
        }

        /// <summary>
        /// Dependency injection constructor to enable testing
        /// </summary>
        public Customers(IServiceHelper serviceHelper)
        {
            _serviceHelper = serviceHelper;
        }

        /// <summary>
        /// Adds a customer to Paydok
        /// </summary>
        /// <param name="request">Stores the customer information to add</param>
        /// <returns>details of the created customer</returns>
        public CustomerResponse Add(CustomerRequest request)
        {
            var requestData = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var responseJson = _serviceHelper.CallPaydock("customers", HttpMethod.POST, requestData);

            var response = (CustomerResponse)JsonConvert.DeserializeObject(responseJson, typeof(CustomerResponse));
            response.JsonResponse = responseJson;
            return response;
        }
    }
}