using System;
using System.Collections.Generic;

namespace CarFuel.Models {
    public class FillUp : IDisposable {
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
        public bool IsFull { get; set; } = true;
        public double Liters { get; set; }
        public int Odometer { get; set; }
        public FillUp NextFillUp { get; set; }
        public void Dispose() {
            throw new NotImplementedException();
        }
        internal int? Distance {
            get {
                return NextFillUp?.Odometer - Odometer;
            }

        }
    }


}