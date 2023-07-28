using System;
using System.Collections.Generic;

namespace Global608.Models;

public partial class Global10Ch2MonthKWrt
{
    public DateTime Time { get; set; }

    public double Ch2kWrt { get; set; }

    public double Rt2 { get; set; }

    public double TotalPower { get; set; }

    public int Count { get; set; }
}
