using System;
using System.Collections.Generic;

namespace Global608.Models;

public partial class Global03AvgHourPower
{
    public DateTime Time { get; set; }

    public double Rt1 { get; set; }

    public double Rt2 { get; set; }

    public double TotalPower { get; set; }

    public double Power1 { get; set; }

    public double Power2 { get; set; }

    public double TotalRt { get; set; }

    public double Ch1Chwflow { get; set; }

    public double Ch1Chwtout { get; set; }

    public double Ch1Chwtin { get; set; }

    public double Ch2Chwflow { get; set; }

    public double Ch2Chwtout { get; set; }

    public double Ch2Chwtin { get; set; }

    public double Ch1Cwflow { get; set; }

    public double Ch1Cwtout { get; set; }

    public double Ch1Cwtin { get; set; }

    public double Ch2Cwtout { get; set; }

    public double Ch1Dbt { get; set; }

    public double Ch2Cwtin { get; set; }

    public double Ch1Rh { get; set; }
}
