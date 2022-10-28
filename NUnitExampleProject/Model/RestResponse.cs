﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitExampleProject.Model
{
    internal class RestResponse
    {

        private int statusCode;
        private string responseData;

        public RestResponse(int statusCode, string responseData)
        {
            this.statusCode = statusCode;
            this.responseData = responseData;
        }

        public int StatusCode

        {
            get{ 
                return statusCode;
            }

        }

        public string ResponseData

        {
            get 
            { 
                return responseData; 
            }

        }

        public override string ToString()
        {
            return string.Format("StatusCode: {0} ResponseData: {1}",statusCode,responseData);
        }
    }
}
