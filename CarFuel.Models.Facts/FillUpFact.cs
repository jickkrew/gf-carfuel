using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
namespace CarFuel.Models.Facts
{
    public class FillUpFact
    {
      public class GeneralUsage {

      [Fact]
      public void NewFillUp() {

        FillUp f;
        f = new FillUp();

        Assert.Equal(0, f.Odometer);
        Assert.Equal(0.0, f.Liters);
        Assert.True(f.IsFull);

      }

    }



    public class ConsumptionRateProp  {

      private FillUp f;

      [Fact]
      public void FirstFillUp_ReturnNull() {
        f = new FillUp();  
        f.Odometer = 1000;
        f.Liters = 40;

        //Act
        double? result = f.ConsumptionRate;

        Assert.Null(result);

        //Assert


      }
      [Fact]
      public void TwoFullFillUps() {

        var f1 = new FillUp();
        f1.Odometer = 1000; f1.Liters = 40.0;

        var f2 = new FillUp();
        f2.Odometer = 1600; f2.Liters = 50.0;

        var f3 = new FillUp();
        f3.Odometer = 2200; f3.Liters = 60.0;

        f1.NextFillUp = f2;
        f2.NextFillUp = f3;

        double? result1 = f1.ConsumptionRate;
        double? result2 = f2.ConsumptionRate;
        double? result3 = f3.ConsumptionRate;



        Assert.Equal(12.0, result1);
        Assert.Null(result3);
       // Assert.Null(result3);
      }

      [Theory]
      [InlineData(1000,40.0,12.0,1600,50)]
      [InlineData(1600,50.0, 10.0, 2200, 60)]
      public void TwoFullFillUps_I(int odo1, double liter1, double kml1,
                                   int obo2 , double liter2) {

        var f1 = new FillUp();
        f1.Odometer = odo1; f1.Liters = liter1;

        var f2 = new FillUp();
        f2.Odometer = obo2; f2.Liters = liter2;
            

        f1.NextFillUp = f2;
     

        double? result1 = f1.ConsumptionRate;
        double? result2 = f2.ConsumptionRate;    



        Assert.Equal(kml1, result1);
        Assert.Null(result2);
        // Assert.Null(result3);
      }
    }
 
}   
}
