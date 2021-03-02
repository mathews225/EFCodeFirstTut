using System;
using System.Linq;
using System.Threading.Tasks;
using EFCodeFirstTut.Models;

namespace EFCodeFirstTut {
	class Program {
		static async Task Main(string[] args) {

			var custCtrl = new CustomerController();
			var orderCtrl = new OrderController();
			var orderlineCtrl = new OrderlineController();
			var itemCtrl = new ItemController();


			#region Create
			#region Customer
			//var created = new DateTime(2021, 3, 2);

			//var cKroger = new Customer {
			//	Id = 0,
			//	Code = "KR",
			//	Name = "Kroger",
			//	IsNational = true,
			//	Sales = 0,
			//	Created = created
			//};

			//var cJJ = new Customer {
			//	Id = 0,
			//	Code = "JJ",
			//	Name = "Jungle Jim's",
			//	IsNational = false,
			//	Sales = 0,
			//	Created = created
			//};

			//var cMeijer = new Customer {
			//	Id = 0,
			//	Code = "M",
			//	Name = "Meijer",
			//	IsNational = false,
			//	Sales = 200.00m,
			//	Created = created
			//};

			//var addKroger = await custCtrl.Create(cKroger);
			//var addJJ = await custCtrl.Create(cJJ);
			//var addMeijer = await custCtrl.Create(cMeijer);
			#endregion
			#region Item

			//var Item1 = new Item {
			//	Id = 0,
			//	Name = "Apples",
			//	Price = 3.98m
			//};
			//var Item2 = new Item {
			//	Id = 0,
			//	Name = "Figs",
			//	Price = 4.47m
			//};
			//var Item3 = new Item {
			//	Id = 0,
			//	Name = "Grapes",
			//	Price = 5.29m
			//};

			//var addItem1 = await itemCtrl.Create(Item1);
			//var addItem2 = await itemCtrl.Create(Item2);
			//var addItem3 = await itemCtrl.Create(Item3);
			#endregion
			#region Order

			//var Order1 = new Order {
			//	Id = 0,
			//	Description = "Apples",
			//	Status = "new",
			//	Total = 3.98m,
			//	CustomerId = 2
			//};
			//var Order2 = new Order {
			//	Id = 0,
			//	Description = "Apples",
			//	Status = "new",
			//	Total = 3312.98m,
			//	CustomerId = 2
			//};
			//var Order3 = new Order {
			//	Id = 0,
			//	Description = "Apples",
			//	Status = "new",
			//	Total = 56.83m,
			//	CustomerId = 1
			//};

			//var addOrder1 = await orderCtrl.Create(Order1);
			//var addOrder2 = await orderCtrl.Create(Order2);
			//var addOrder3 = await orderCtrl.Create(Order3);
			#endregion
			#region Orderline

			//var Orderline1 = new Orderline {
			//	Id = 0,
			//	OrderId = 1,
			//	ItemId = 1,
			//	Quantity = 1
			//};
			//var Orderline2 = new Orderline {
			//	Id = 0,
			//	OrderId = 2,
			//	ItemId = 2,
			//	Quantity = 2
			//};
			//var Orderline3 = new Orderline {
			//	Id = 0,
			//	OrderId = 3,
			//	ItemId = 3,
			//	Quantity = 2
			//};

			//var addOrderline1 = await orderlineCtrl.Create(Orderline1);
			//var addOrderline2 = await orderlineCtrl.Create(Orderline2);
			//var addOrderline3 = await orderlineCtrl.Create(Orderline3);
			#endregion
			#endregion

			#region Read All
			#region Customer
			var customer = await custCtrl.GetAll();
			foreach (var v in customer) {
				Console.WriteLine("{0,-12}{1,-12}", v.Id, v.Name);
			}
			Console.WriteLine("\n");

			#endregion
			#region Item
			var item = await itemCtrl.GetAll();
			foreach (var v in item) {
				Console.WriteLine("{0,-12}{1,-12}", v.Id, v.Name);
			}
			Console.WriteLine("\n");

			#endregion
			#region Order
			var order = await orderCtrl.GetAll();
			foreach (var v in order) {
				Console.WriteLine("{0,6}{1,-12}{2,-14}", v.Id, v.Description, v.Status);
			}
			Console.WriteLine("\n");
			#endregion
			#region Orderline
			var orderline = await orderlineCtrl.GetAll();
			foreach (var v in orderline) {
				Console.WriteLine("{0,6}{1,6}{2,6}{3,6}", v.Id, v.OrderId, v.ItemId, v.Quantity);
			}
			Console.WriteLine("\n");
			#endregion
			#endregion

			#region Read One
			#region Customer

			#endregion
			#region Item

			#endregion
			#region Order

			#endregion
			#region Orderline

			#endregion
			#endregion

			#region Update
			#region Customer

			#endregion
			#region Item

			#endregion
			#region Order

			#endregion
			#region Orderline

			#endregion
			#endregion

			#region Delete
			#region Customer

			#endregion
			#region Item

			#endregion
			#region Order

			#endregion
			#region Orderline

			#endregion
			#endregion




		}
	}
}
/*
Customer
	Id
	Code
	Name
	IsNational
	Sales
	Created
Items
	Id
	Name
	Price
Orderlines
	Id
	OrderId
	ItemId
	Quantity
Order
	Id
	Description
	Status
	Total
	CustomerId
*/