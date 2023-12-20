using System.ComponentModel;

namespace ProtonNexus.Core.Domain.Enums;

public enum VehicleEnum
{
    [Description("Repairs the vehicle")] RepairVehicle,

    [Description("Makes the vehicle indestructible")]
    Indestructible
}