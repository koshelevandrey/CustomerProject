﻿using System;

namespace CustomerLibrary
{
    public abstract class Person
    {
        public string FirstName;
        public string LastName;

        public Person(string lastName)
        {
            LastName = lastName;
            FirstName = "";
        }
    }
}