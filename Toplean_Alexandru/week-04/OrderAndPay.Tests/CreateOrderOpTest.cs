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

namespace OrderAndPay.Tests
{
    public class CreateOrderOpTest : OpTest
    {
        [Theory]
        [CarthesianProductOf(typeof(CreateOrderCmdInput), typeof(CreateOrderOp.PaymentEffect))]
        public async Task Run_CreateOp_Specs(params object[] path)
        {
            var cmd = new CreateOrderCmdInputGen().Get(path.OfType<CreateOrderCmdInput>().First());

            var expr = from order in RestaurantDomain.CreateOrder(cmd.Order)
                       select order;

            var result = await TestExpr(expr, path);
        }

        //[Theory]
        //[CarthesianProductOf(typeof(CreateOrderCmdInput), typeof(CreateOrderOp.OrderEffect))]
        //public async Task CreateOrderTests(params object[] path)
        //{
        //    var cmd = new CreateOrderCmdInputGen().Get(path.OfType<CreateOrderCmdInput>().First());

        //    var expr = from order in RestaurantDomain.CreateOrder(cmd.Order)
        //               select order;

        //    var result = await TestExpr(expr, path);
        //}
    }
}