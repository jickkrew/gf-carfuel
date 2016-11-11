using CarFuel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarFuel.Services.Facts {
   public class CarServiceFact {

        public class Add {

            [Fact]
            public void PlateNoMustBeUniqued() {
                // in situation 's' will call carservice but
                //  we use Fake to runtest
                var repo = new FakeRepository<Car>();
                var s = new CarService(repo);
                var c1 = new Car { PlateNo = "123" };
                var c2 = new Car { PlateNo = "123" };

                s.Add(c1);

                Assert.Throws<Exception>(() => {
                    s.Add(c2);
                });
            }
        }
        
    }
}
