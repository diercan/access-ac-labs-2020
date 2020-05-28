using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain;
using Domain.Domain.CreateOrderOp;
using Infra;
using Infra.Free;
using Xunit;

namespace OpTests
{
    public class CreateOpTests : OpTest
    {
        [Theory]
        [CarthesianProductOf(typeof(CreateOrderCmdInput), typeof(CreateOrderOp.PaymentEffect))]
        public async Task Run_CreateOp_Specs(params object[] path)
        {
            var cmd = new CreateOrderCmdInputGen().Get(path.OfType<CreateOrderCmdInput>().First());

            var expr = from order in RestaurantDomain.CreateOrder(cmd.ClientId, cmd.RestaurantId, cmd.TableNumber,
                    cmd.ItemNames, cmd.ItemQuantities, cmd.ItemComments, cmd.TotalPrice, cmd.Status, cmd.PaymentStatus)
                       select order;

            var result = await TestExpr(expr, path);
        }
    }
}
