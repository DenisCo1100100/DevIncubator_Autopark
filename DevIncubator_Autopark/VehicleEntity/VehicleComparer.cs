using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DevIncubator_Autopark.VehicleEntity
{
    internal class VehicleComparer : IComparer<Vehicle>
    {
        public int Compare([AllowNull] Vehicle x, [AllowNull] Vehicle y) => x.Model.CompareTo(y.Model);
    }
}
