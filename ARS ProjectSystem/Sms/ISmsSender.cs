﻿using System.Threading.Tasks;

namespace ARS_ProjectSystem.Sms
{
    public interface ISmsSender
    {
            Task SendSmsAsync(string number, string message);

    }
}