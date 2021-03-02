using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTut.Models {
	public class OrderController {

		private readonly AppDbContext _context;

		public async Task<IEnumerable<Order>> GetAll() {
			return await _context.Orders.ToListAsync();
		}

		public async Task<Order> GetByPK(int id) {
			return await _context.Orders.FindAsync(id);
		}

		public async Task<Order> Create(Order order) {
			if (order == null) {
				throw new Exception("ERROR: ORDER CANNOT BE NULL");
			}
			if (order.Id != 0) {
				throw new Exception("ERROR: ORDER ID MUST BE 0");
			}
			_context.Add(order);
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1) {
				throw new Exception("ERROR: ORDER WAS NOT CREATED");
			}
			return order;
		}

		public async Task Update(Order order) {
			if (order == null) {
				throw new Exception("ERROR: ORDER CANNOT BE NULL");
			}
			if (order.Id != 0) {
				throw new Exception("ERROR: ORDER ID MUST BE GREATER THAN 0");
			}
			_context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1) {
				throw new Exception("ERROR: ORDER WAS NOT UPDATED");
			}
			return;
		}

		public async Task<Order> Delete(int id) {
			var order = await _context.Orders.FindAsync(id);
			if (order == null) {
				return null;
			}
			int count = await _context.Orderlines.Where(s => s.OrderId == order.Id).CountAsync();
			if (count != 0) {
				throw new Exception($"ERROR: Cannot delete major. {count} Student(s) with major");
			}
			_context.Orders.Remove(order);
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1) {
				throw new Exception("ERROR: Remove Failed");
			}
			Console.WriteLine($"ORDER DELETED!");
			return order;
		}

		public OrderController() {
			_context = new AppDbContext();
		}
	}

}
