using System;
using System.Collections.Generic;

namespace CarFuel.Models {
    public class FillUp : IDisposable {

        public int id { get; set; }
        public bool IsFull { get; set; } = true;
        public double Liters { get; set; }
        public int Odometer { get; set; }
        public virtual FillUp NextFillUp { get; set; }
        
        public double? ConsumptionRate {
            get {
                if (NextFillUp == null) {
                    return null;
                }
                else {
                    return (NextFillUp.Odometer - Odometer) / NextFillUp.Liters;
                }
            }


        }
        internal int? Distance {
            get {
                return NextFillUp?.Odometer - Odometer;
            }

        }
        public void Dispose() {
            throw new NotImplementedException();
        }
    }


}