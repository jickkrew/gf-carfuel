using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CarFuel.Models {
    public class Car {

        public Car() {
            Make = "Make";
            Modal = "Model";
            FillUps = new List<FillUp>();
        }

        public IList<FillUp> FillUps { get; set; }
        public string Make { get; set; }
        public string Modal { get; set; }
        public double? AverageConsumptionRate {
            get {

                int? PrevOdo = 0;
                double PrevLiter = 0.0;

                foreach (FillUp item in FillUps) {
                    if (item.Distance != null) {
                        PrevOdo += item.Distance;
                        PrevLiter += item.Liters;
                    }
                    else {
                        PrevLiter += item.Liters;
                    }
                }
                PrevLiter = PrevLiter - FillUps[0].Liters;
                if (PrevOdo == 0 && PrevLiter == 0) {
                    return null;
                }
                else {
                    if ((FillUps.Count - 1) != 0) {
                        return Math.Round((PrevOdo / PrevLiter) ?? 0.0, 2, MidpointRounding.AwayFromZero);
                    }
                    else {
                        return null;
                    }
                }


                //if (FillUps.Count <= 1) {
                //    return null;
                //}

                //int? totalDistance = FillUps.Sum(f => f.Distance);
                //double? totalLiters = FillUps.Sum(f => f.Liters) - FillUps.FirstOrDefault()?.Liters;

                //return Math.Round((totalDistance / totalLiters) ?? 0.0, 2, MidpointRounding.AwayFromZero);

            }

        }


        public FillUp AddFillUp(int odometer, double liters) {
            var f = new FillUp() {
                Odometer = odometer,
                Liters = liters
            };

            if (FillUps.Count > 0) {
                FillUps[FillUps.Count - 1].NextFillUp = f;
            }

            FillUps.Add(f);

            return f;

        }


    }
}