﻿using PeripheralTech.Mobile.Validators.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Mobile.Validators.Implementations
{
    public class RequiredValidator : IValidator
    {
        public string Message { get; set; } = "This field is required";

        public bool Check(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
