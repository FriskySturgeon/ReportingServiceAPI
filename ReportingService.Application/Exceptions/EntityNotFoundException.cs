﻿
using System.Net;

namespace ReportingService.Application.Exceptions
{
    public class EntityNotFoundException(string message) : Exception(message)
    { }
}
