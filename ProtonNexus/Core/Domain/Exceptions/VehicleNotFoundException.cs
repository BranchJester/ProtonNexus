using System;

namespace ProtonNexus.Core.Domain.Exceptions;

public class VehicleNotFoundException : Exception
{
    public VehicleNotFoundException(string message) : base(message)
    {
    }

    public VehicleNotFoundException() : base("You're not in a vehicle.")
    {
    }
}