using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CarFuel.Models {
    public class Car {

        public Car() {
            Make = "Honda";
            Model = "City";
            FillUps = new HashSet<FillUp>();
        }
      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required,StringLength(10)]
        public string PlateNo { get; set; }

        [StringLength(30)]
        public string Color { get; set; }

        [Required]
        [StringLength(20)]
        [Description("Make")]
        public string Make { get; set; }

        [Required]
        [StringLength(30)]       
        public string Model { get; set; }
        public virtual ICollection<FillUp> FillUps { get; set; }

        public double? AverageConsumptionRate {
            get {

                //int? PrevOdo = 0;
                //double PrevLiter = 0.0;

                //foreach (FillUp item in FillUps) {
                //    if (item.Distance != null) {
                //        PrevOdo += item.Distance;
                //        PrevLiter += item.Liters;
                //    }
                //    else {
                //        PrevLiter += item.Liters;
                //    }
                //}
                //PrevLiter = PrevLiter - FillUps[0].Liters;
                //if (PrevOdo == 0 && PrevLiter == 0) {
                //    return null;
                //}
                //else {
                //    if ((FillUps.Count - 1) != 0) {
                //        return Math.Round((PrevOdo / PrevLiter) ?? 0.0, 2, MidpointRounding.AwayFromZero);
                //    }
                //    else {
                //        return null;
                //    }
                //}

                if (FillUps.Count <= 1) {
                    return null;
                }

                int? totalDistance = FillUps.Sum(f => f.Distance);
                
                double? totalLiters = FillUps.Sum(f => f.Liters) - FillUps.OrderBy(f => f.Odometer).FirstOrDefault()?.Liters;

                return Math.Round((totalDistance / totalLiters) ?? 0.0, 2, MidpointRounding.AwayFromZero);

            }

        }
        public FillUp AddFillUp(int odometer, double liters) {
            var f = new FillUp() {
                Odometer = odometer,
                Liters = liters  };
            //if (FillUps.Count > 0) {
            //    FillUps[FillUps.Count - 1].NextFillUp = f;
            //}
            if (FillUps.Any<FillUp>()) {

                FillUps.OrderBy(x => x.Odometer).Last().NextFillUp = f;
            }

            FillUps.Add(f);

            return f;

        }


    }
}