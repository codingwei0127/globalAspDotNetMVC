using System;
using System.Collections.Generic;

namespace Global608.Models;

public partial class Global09Ch1MonthKWrt
{
    public DateTime Time { get; set; }

    public double Ch1kWrt { get; set; }

    public double Rt1 { get; set; }

    public double TotalPower { get; set; }

    public int Count { get; set; }
}
