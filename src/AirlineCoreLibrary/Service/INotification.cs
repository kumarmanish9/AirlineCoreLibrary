﻿using AirlineCoreLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCoreLibrary.Service
{
    public interface INotification
    {
        Task<bool?> SendNotification(PassengerCompenation? passenger);
    }
}
