﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AmazonTestCases.Models
{
    public static class Homepage
    {
        public static string BaseUrl = @"https://www.amazon.com/";

        public static string GetUrl()
        {
            return BaseUrl;
        }

    }
}
