﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Helper
{
    public class Resultion
    {
        private bool isSuccess;
        private string message;
        private object value;

        public Resultion()
        {

        }

        public Resultion(bool isSuccess,string message,object value)
        {
            this.isSuccess = isSuccess;
            this.message = message;
            this.value = value;
        }

        public bool IsSuccess
        {
            get
            {
                return this.isSuccess;
            }
            set
            {
                this.isSuccess = value;
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }

        public object Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }
}
